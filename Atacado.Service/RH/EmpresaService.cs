using Atacado.EF.Database;
using Atacado.Envelope.RH;
using Atacado.Mapper.Ancestral;
using Atacado.Poco.RH;
using Atacado.Repository.RH;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.RH
{
    public class EmpresaService : BaseEnvelopadaService<EmpresaPoco, Empresa, EmpresaEnvelopeJSON>
    {
        private EmpresaRepository repositorio;

        public EmpresaService() : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<EmpresaPoco, Empresa, EmpresaEnvelopeJSON>();
            this.repositorio = new EmpresaRepository(new AtacadoContext());
        }

        public EmpresaService(AtacadoContext contexto) : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<EmpresaPoco, Empresa, EmpresaEnvelopeJSON>();
            this.repositorio = new EmpresaRepository(contexto);
        }

        public override List<EmpresaEnvelopeJSON> Listar()
        {
            List<Empresa> listDom = this.repositorio.Read().ToList();
            return ProcessarListaDOM(listDom);
        }

        public List<EmpresaEnvelopeJSON> Listar(int pular, int exibir)
        {
            List<Empresa> listDom = this.repositorio.Read(pular, exibir).ToList();
            return ProcessarListaDOM(listDom);
        }

        protected override List<EmpresaEnvelopeJSON> ProcessarListaDOM(List<Empresa> listDom)
        {
            List<EmpresaEnvelopeJSON> lista = listDom.Select(dom => this.mapeador.Mecanismo.Map<EmpresaEnvelopeJSON>(dom)).ToList();
            lista.ForEach(json => json.SetLinks());
            return lista;
        }

        public override EmpresaEnvelopeJSON Atualizar(EmpresaPoco obj)
        {
            Empresa antes = this.mapeador.Mecanismo.Map<Empresa>(obj);
            Empresa editado = this.repositorio.Edit(antes);
            EmpresaEnvelopeJSON json = this.mapeador.Mecanismo.Map<EmpresaEnvelopeJSON>(editado);
            json.SetLinks();
            return json;
        }

        public override EmpresaEnvelopeJSON Criar(EmpresaPoco obj)
        {
            Empresa novo = this.mapeador.Mecanismo.Map<Empresa>(obj);
            Empresa criado = this.repositorio.Add(novo);
            EmpresaEnvelopeJSON json = this.mapeador.Mecanismo.Map<EmpresaEnvelopeJSON>(criado);
            json.SetLinks();
            return json;
        }

        public override EmpresaEnvelopeJSON Excluir(int id)
        {
            Empresa excluido = this.repositorio.DeleteById(id);
            EmpresaEnvelopeJSON json = this.mapeador.Mecanismo.Map<EmpresaEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }

        public override EmpresaEnvelopeJSON Excluir(EmpresaPoco obj)
        {
            return this.Excluir(Convert.ToInt32(obj.IdEmpresa));
        }

        public override EmpresaEnvelopeJSON Selecionar(int id)
        {
            Empresa selecionado = this.repositorio.Read(id);
            EmpresaEnvelopeJSON json = this.mapeador.Mecanismo.Map<EmpresaEnvelopeJSON>(selecionado);
            json.SetLinks();
            return json;
        }
    }
}

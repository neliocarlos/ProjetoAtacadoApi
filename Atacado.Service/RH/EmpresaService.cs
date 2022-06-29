using Atacado.EF.Database;
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
    public class EmpresaService : BaseAncestralService<EmpresaPoco, Empresa>
    {
        private EmpresaRepository repositorio;

        public EmpresaService() : base()
        {
            this.mapeador = new MapeadorGenerico<EmpresaPoco, Empresa>();
            this.repositorio = new EmpresaRepository(new AtacadoContext());
        }

        public override List<EmpresaPoco> Listar()
        {
            List<Empresa> listDom = this.repositorio.Read().ToList();
            return ProcessarListaDOM(listDom);
        }

        public List<EmpresaPoco> Listar(int pular, int exibir)
        {
            List<Empresa> listDom = this.repositorio.Read(pular, exibir).ToList();
            return ProcessarListaDOM(listDom);
        }

        protected override List<EmpresaPoco> ProcessarListaDOM(List<Empresa> listDom)
        {
            return listDom.Select(dom => this.mapeador.Mecanismo.Map<EmpresaPoco>(dom)).ToList();
        }

        public override EmpresaPoco Atualizar(EmpresaPoco obj)
        {
            Empresa antes = this.mapeador.Mecanismo.Map<Empresa>(obj);
            Empresa editado = this.repositorio.Edit(antes);
            EmpresaPoco poco = this.mapeador.Mecanismo.Map<EmpresaPoco>(obj);
            return poco;
        }

        public override EmpresaPoco Criar(EmpresaPoco obj)
        {
            Empresa novo = this.mapeador.Mecanismo.Map<Empresa>(obj);
            Empresa criado = this.repositorio.Add(novo);
            EmpresaPoco poco = this.mapeador.Mecanismo.Map<EmpresaPoco>(criado);
            return poco;
        }

        public override EmpresaPoco Excluir(int id)
        {
            Empresa excluido = this.repositorio.DeleteById(id);
            EmpresaPoco poco = this.mapeador.Mecanismo.Map<EmpresaPoco>(excluido);
            return poco;
        }

        public override EmpresaPoco Excluir(EmpresaPoco obj)
        {
            return this.Excluir(Convert.ToInt32(obj.IdEmpresa));
        }

        public override EmpresaPoco Selecionar(int id)
        {
            Empresa selecionado = this.repositorio.Read(id);
            EmpresaPoco poco = this.mapeador.Mecanismo.Map<EmpresaPoco>(selecionado);
            return poco;
        }
    }
}

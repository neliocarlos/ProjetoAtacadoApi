using Atacado.Service.Ancestral;
using Atacado.Poco.Auxiliar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atacado.Mapper.Ancestral;
using Atacado.EF.Database;
using Atacado.Repository.Auxiliar;

namespace Atacado.Service.Auxiliar
{
    public class ProfissaoService : BaseAncestralService<ProfissaoPoco, Profissao>
    {
        private ProfissaoRepository repositorio;

        public ProfissaoService()
        {
            this.mapeador = new MapeadorGenerico<ProfissaoPoco, Profissao>();
            this.repositorio = new ProfissaoRepository(new AtacadoContext());
        }

        public override List<ProfissaoPoco> Listar()
        {
            List<Profissao> listDom = this.repositorio.Read().ToList();
            return ProcessarListaDOM(listDom);
        }

        public List<ProfissaoPoco> Listar(int pular, int exibir)
        {
            List<Profissao> listDom = this.repositorio.Read(pular, exibir).ToList();
            return ProcessarListaDOM(listDom);
        }

        protected override List<ProfissaoPoco> ProcessarListaDOM(List<Profissao> listDom)
        {
            return listDom.Select(dom => this.mapeador.Mecanismo.Map<ProfissaoPoco>(dom)).ToList();
        }

        public override ProfissaoPoco Selecionar(int id)
        {
            Profissao dom = this.repositorio.Read(id);
            ProfissaoPoco poco = this.mapeador.Mecanismo.Map<ProfissaoPoco>(dom);
            return poco;
        }

        public override ProfissaoPoco Criar(ProfissaoPoco obj)
        {
            Profissao dom = this.mapeador.Mecanismo.Map<Profissao>(obj);
            Profissao criado = this.repositorio.Add(dom);
            ProfissaoPoco poco = this.mapeador.Mecanismo.Map<ProfissaoPoco>(criado);
            return poco;
        }

        public override ProfissaoPoco Atualizar(ProfissaoPoco obj)
        {
            Profissao dom = this.mapeador.Mecanismo.Map<Profissao>(obj);
            Profissao atualizado = this.repositorio.Edit(dom);
            ProfissaoPoco poco = this.mapeador.Mecanismo.Map<ProfissaoPoco>(atualizado);
            return poco;
        }

        public override ProfissaoPoco Excluir(int id)
        {
            Profissao excluido = this.repositorio.DeleteById(id);
            ProfissaoPoco poco = this.mapeador.Mecanismo.Map<ProfissaoPoco>(excluido);
            return poco;
        }

        public override ProfissaoPoco Excluir(ProfissaoPoco obj)
        {
            return this.Excluir(obj.IdProfissao);
        }

    }
}

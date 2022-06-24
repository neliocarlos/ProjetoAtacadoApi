using Atacado.Dal.Auxiliar;
using Atacado.EF.Database;
using Atacado.Mapper.Auxiliar;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Auxiliar
{
    public class RebanhoService : BaseAncestralService<RebanhoPoco>
    {
        private RebanhoMapper mapConfig;
        private RebanhoDao dao;

        public RebanhoService()
        {
            this.mapConfig = new RebanhoMapper();
            this.dao = new RebanhoDao();
        }

        public List<RebanhoPoco> Listar(int pular, int exibir)
        {
            List<Rebanho> listDom = this.dao.ReadAll(pular, exibir);
            return ProcessarListaDOM(listDom);
        }

        public List<RebanhoPoco> FiltrarPorAnoRefIdMun(int anoRef, int idMun)
        {
            List<Rebanho> listDom = 
                this.dao.QueryBy(reb => (reb.AnoRef == anoRef) && (reb.IdMunicipio == idMun)).ToList();
            return ProcessarListaDOM(listDom);
        }

        private List<RebanhoPoco> ProcessarListaDOM(List<Rebanho> listDom)
        {
            List<RebanhoPoco> listPoco = new List<RebanhoPoco>();
            foreach (Rebanho item in listDom)
            {
                RebanhoPoco poco = this.mapConfig.Mapper.Map<RebanhoPoco>(listDom);
                listPoco.Add(poco);
            }
            return listPoco;
        }

        public override RebanhoPoco Selecionar(int id)
        {
            Rebanho dom = this.dao.Read(id);
            RebanhoPoco poco = this.mapConfig.Mapper.Map<RebanhoPoco>(dom);
            return poco;
        }

        public override RebanhoPoco Criar(RebanhoPoco obj)
        {
            Rebanho dom = this.mapConfig.Mapper.Map<Rebanho>(obj);
            Rebanho criado = this.dao.Create(dom);
            RebanhoPoco poco = this.mapConfig.Mapper.Map<RebanhoPoco>(criado);
            return poco;
        }

        public override RebanhoPoco Atualizar(RebanhoPoco obj)
        {
            Rebanho dom = this.mapConfig.Mapper.Map<Rebanho>(obj);
            Rebanho atualizado = this.dao.Update(dom);
            RebanhoPoco poco = this.mapConfig.Mapper.Map<RebanhoPoco>(atualizado);
            return poco;
        }

        public override RebanhoPoco Excluir(int id)
        {
            Rebanho excluido = this.dao.Delete(id);
            RebanhoPoco poco = this.mapConfig.Mapper.Map<RebanhoPoco>(excluido);
            return poco;
        }

        public override RebanhoPoco Excluir(RebanhoPoco obj)
        {
            return this.Excluir(obj.IdRebanho);
        }
    }
}

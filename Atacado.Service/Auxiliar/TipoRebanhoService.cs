﻿using Atacado.Dal.Auxiliar;
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
    public class TipoRebanhoService : BaseAncestralService<TipoRebanhoPoco>
    {
        private TipoRebanhoMapper mapConfig;
        private TipoRebanhoDao dao;

        public TipoRebanhoService()
        {
            this.mapConfig = new TipoRebanhoMapper();
            this.dao = new TipoRebanhoDao();
        }

        public override List<TipoRebanhoPoco> Listar()
        {
            List<TipoRebanho> listDom = this.dao.ReadAll();
            return ProcessarListaDOM(listDom);
        }

        public List<TipoRebanhoPoco> Listar(int pular, int exibir)
        {
            List<TipoRebanho> listDom = this.dao.ReadAll(pular, exibir);
            return ProcessarListaDOM(listDom);
        }

        private List<TipoRebanhoPoco> ProcessarListaDOM(List<TipoRebanho> listDom)
        {
            List<TipoRebanhoPoco> listPoco = new List<TipoRebanhoPoco>();
            foreach (TipoRebanho item in listDom)
            {
                TipoRebanhoPoco poco = this.mapConfig.Mapper.Map<TipoRebanhoPoco>(listDom);
                listPoco.Add(poco);
            }
            return listPoco;
        }

        public override TipoRebanhoPoco Selecionar(int id)
        {
            TipoRebanho dom = this.dao.Read(id);
            TipoRebanhoPoco poco = this.mapConfig.Mapper.Map<TipoRebanhoPoco>(dom);
            return poco;
        }

        public override TipoRebanhoPoco Criar(TipoRebanhoPoco obj)
        {
            TipoRebanho dom = this.mapConfig.Mapper.Map<TipoRebanho>(obj);
            TipoRebanho criado = this.dao.Create(dom);
            TipoRebanhoPoco poco = this.mapConfig.Mapper.Map<TipoRebanhoPoco>(criado);
            return poco;
        }

        public override TipoRebanhoPoco Atualizar(TipoRebanhoPoco obj)
        {
            TipoRebanho dom = this.mapConfig.Mapper.Map<TipoRebanho>(obj);
            TipoRebanho atualizado = this.dao.Update(dom);
            TipoRebanhoPoco poco = this.mapConfig.Mapper.Map<TipoRebanhoPoco>(atualizado);
            return poco;
        }

        public override TipoRebanhoPoco Excluir(int id)
        {
            TipoRebanho excluido = this.dao.Delete(id);
            TipoRebanhoPoco poco = this.mapConfig.Mapper.Map<TipoRebanhoPoco>(excluido);
            return poco;
        }

        public override TipoRebanhoPoco Excluir(TipoRebanhoPoco obj)
        {
            return this.Excluir(obj.IdTipo);
        }
    }
}

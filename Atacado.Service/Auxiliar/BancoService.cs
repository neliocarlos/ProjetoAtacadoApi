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
    public class BancoService : BaseAncestralService<BancoPoco>
    {
        private BancoMapper mapConfig;
        private BancoDao dao;

        public BancoService()
        {
            this.mapConfig = new BancoMapper();
            this.dao = new BancoDao();
        }

        public override List<BancoPoco> Listar()
        {
            List<Banco> listDom = this.dao.ReadAll();
            return ProcessarListaDOM(listDom);
        }

        public List<BancoPoco> Listar(int pular, int exibir)
        {
            List<Banco> listDom = this.dao.ReadAll(pular, exibir);
            return ProcessarListaDOM(listDom);
        }

        private List<BancoPoco> ProcessarListaDOM(List<Banco> listDom)
        {
            List<BancoPoco> listPoco = new List<BancoPoco>();
            foreach (Banco banco in listDom)
            {
                BancoPoco poco = this.mapConfig.Mapper.Map<BancoPoco>(listDom);
                listPoco.Add(poco);
            }
            return listPoco;
        }

        public override BancoPoco Selecionar(int id)
        {
            Banco dom = this.dao.Read(id);
            BancoPoco poco = this.mapConfig.Mapper.Map<BancoPoco>(dom);
            return poco;
        }

        public override BancoPoco Criar(BancoPoco obj)
        {
            Banco dom = this.mapConfig.Mapper.Map<Banco>(obj);
            Banco criado = this.dao.Create(dom);
            BancoPoco poco = this.mapConfig.Mapper.Map<BancoPoco>(criado);
            return poco;
        }

        public override BancoPoco Atualizar(BancoPoco obj)
        {
            Banco dom = this.mapConfig.Mapper.Map<Banco>(obj);
            Banco atualizado = this.dao.Update(dom);
            BancoPoco poco = this.mapConfig.Mapper.Map<BancoPoco>(atualizado);
            return poco;
        }

        public override BancoPoco Excluir(int id)
        {
            Banco excluido = this.dao.Delete(id);
            BancoPoco poco = this.mapConfig.Mapper.Map<BancoPoco>(excluido);
            return poco;
        }

        public override BancoPoco Excluir(BancoPoco obj)
        {
            return this.Excluir(obj.IdBanco);
        }
    }
}

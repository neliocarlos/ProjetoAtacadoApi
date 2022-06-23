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
    public class IdiomaService : BaseAncestralService<IdiomaPoco>
    {
        private IdiomaMapper mapConfig;
        private IdiomaDao dao;

        public IdiomaService()
        {
            this.mapConfig = new IdiomaMapper();
            this.dao = new IdiomaDao();
        }

        public override List<IdiomaPoco> Listar()
        {
            List<Idioma> listDom = this.dao.ReadAll();
            return ProcessarListaDOM(listDom);
        }

        public List<IdiomaPoco> Listar(int pular, int exibir)
        {
            List<Idioma> listDom = this.dao.ReadAll(pular, exibir);
            return ProcessarListaDOM(listDom);
        }

        private List<IdiomaPoco> ProcessarListaDOM(List<Idioma> listDom)
        {
            List<IdiomaPoco> listPoco = new List<IdiomaPoco>();
            foreach (Idioma banco in listDom)
            {
                IdiomaPoco poco = this.mapConfig.Mapper.Map<IdiomaPoco>(listDom);
                listPoco.Add(poco);
            }
            return listPoco;
        }

        public override IdiomaPoco Selecionar(int id)
        {
            Idioma dom = this.dao.Read(id);
            IdiomaPoco poco = this.mapConfig.Mapper.Map<IdiomaPoco>(dom);
            return poco;
        }

        public override IdiomaPoco Criar(IdiomaPoco obj)
        {
            Idioma dom = this.mapConfig.Mapper.Map<Idioma>(obj);
            Idioma criado = this.dao.Create(dom);
            IdiomaPoco poco = this.mapConfig.Mapper.Map<IdiomaPoco>(criado);
            return poco;
        }

        public override IdiomaPoco Atualizar(IdiomaPoco obj)
        {
            Idioma dom = this.mapConfig.Mapper.Map<Idioma>(obj);
            Idioma atualizado = this.dao.Update(dom);
            IdiomaPoco poco = this.mapConfig.Mapper.Map<IdiomaPoco>(atualizado);
            return poco;
        }

        public override IdiomaPoco Excluir(int id)
        {
            Idioma excluido = this.dao.Delete(id);
            IdiomaPoco poco = this.mapConfig.Mapper.Map<IdiomaPoco>(excluido);
            return poco;
        }

        public override IdiomaPoco Excluir(IdiomaPoco obj)
        {
            return this.Excluir(obj.IdIdioma);
        }

    }
}

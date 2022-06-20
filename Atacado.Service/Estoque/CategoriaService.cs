﻿using Atacado.Poco.Estoque;
using Atacado.EF.Database;
using Atacado.Mapper.Estoque;
using Atacado.Service.Ancestral;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atacado.Dal.Estoque;

namespace Atacado.Service.Estoque
{
    public class CategoriaService : BaseAncestralService<CategoriaPoco>
    {
        private CategoriaMapper mapConfig;
        private CategoriaDao dao;

        public CategoriaService()
        {
            this.mapConfig = new CategoriaMapper();
            this.dao = new CategoriaDao();
        }

        public override List<CategoriaPoco> Listar()
        {
            List<Categoria> listDom = this.dao.ReadAll();
            List<CategoriaPoco> listPoco = new List<CategoriaPoco>();
            foreach (Categoria item in listDom)
            {
                CategoriaPoco poco = this.mapConfig.Mapper.Map<CategoriaPoco>(item);
                listPoco.Add(poco);
            }                
            return listPoco;
        }

        public override CategoriaPoco Selecionar(int id)
        {
            Categoria dom = this.dao.Read(id);
            CategoriaPoco poco = this.mapConfig.Mapper.Map<CategoriaPoco>(dom);
            return poco;
        }

        public override CategoriaPoco Criar(CategoriaPoco obj)
        {
            Categoria dom = this.mapConfig.Mapper.Map<Categoria>(obj);
            Categoria criado = this.dao.Create(dom);
            CategoriaPoco poco = this.mapConfig.Mapper.Map<CategoriaPoco>(criado);
            return poco;
        }

        public override CategoriaPoco Atualizar(CategoriaPoco obj)
        {
            Categoria dom = this.mapConfig.Mapper.Map<Categoria>(obj);
            Categoria atualizado = this.dao.Update(dom);
            CategoriaPoco poco = this.mapConfig.Mapper.Map<CategoriaPoco>(atualizado);
            return poco;
        }

        public override CategoriaPoco Excluir(CategoriaPoco obj)
        {
            return this.Excluir(obj.Codigo);
        }

        public override CategoriaPoco Excluir(int id)
        {
            Categoria excluido = this.dao.Delete(id);
            CategoriaPoco poco = this.mapConfig.Mapper.Map<CategoriaPoco>(excluido);
            return poco;
        }
    }
}
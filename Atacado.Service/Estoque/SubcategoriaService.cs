﻿using Atacado.Dal.Estoque;
using Atacado.EF.Database;
using Atacado.Mapper.Estoque;
using Atacado.Poco.Estoque;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Estoque
{
    public class SubcategoriaService : BaseAncestralService<SubcategoriaPoco>
    {
        private SubcategoriaMapper mapConfig;
        private SubcategoriaDao dao;

        public SubcategoriaService()
        {
            this.mapConfig = new SubcategoriaMapper();
            this.dao = new SubcategoriaDao();
        }

        public override List<SubcategoriaPoco> Listar()
        {
            List<Subcategoria> listDom = this.dao.ReadAll();
            return ProcessarListaDOM(listDom);
        }

        public List<SubcategoriaPoco> Listar(int pular, int exibir)
        {
            List<Subcategoria> listDom = this.dao.ReadAll(pular, exibir);
            return ProcessarListaDOM(listDom);
        }

        private List<SubcategoriaPoco> ProcessarListaDOM(List<Subcategoria> listDom)
        {
            List<SubcategoriaPoco> listPoco = new List<SubcategoriaPoco>();
            foreach (Subcategoria item in listDom)
            {
                SubcategoriaPoco poco = this.mapConfig.Mapper.Map<SubcategoriaPoco>(item);
                listPoco.Add(poco);
            }
            return listPoco;
        }

        public override SubcategoriaPoco Selecionar(int id)
        {
            Subcategoria dom = this.dao.Read(id);
            SubcategoriaPoco poco = this.mapConfig.Mapper.Map<SubcategoriaPoco>(dom);
            return poco;
        }

        public override SubcategoriaPoco Criar(SubcategoriaPoco obj)
        {
            Subcategoria dom = this.mapConfig.Mapper.Map<Subcategoria>(obj);
            Subcategoria criado = this.dao.Create(dom);
            SubcategoriaPoco poco = this.mapConfig.Mapper.Map<SubcategoriaPoco>(criado);
            return poco;
        }

        public override SubcategoriaPoco Atualizar(SubcategoriaPoco obj)
        {
            Subcategoria dom = this.mapConfig.Mapper.Map<Subcategoria>(obj);
            Subcategoria atualizado = this.dao.Update(dom);
            SubcategoriaPoco poco = this.mapConfig.Mapper.Map<SubcategoriaPoco>(atualizado);
            return poco;
        }

        public override SubcategoriaPoco Excluir(SubcategoriaPoco obj)
        {
            return this.Excluir(obj.IdSubcategoria);
        }

        public override SubcategoriaPoco Excluir(int id)
        {
            Subcategoria excluido = this.dao.Delete(id);
            SubcategoriaPoco poco = this.mapConfig.Mapper.Map<SubcategoriaPoco>(excluido);
            return poco;
        }
    }
}

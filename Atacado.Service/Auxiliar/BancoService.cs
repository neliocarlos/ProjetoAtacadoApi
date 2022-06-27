﻿using Atacado.EF.Database;
using Atacado.Mapper.Auxiliar;
using Atacado.Poco.Auxiliar;
using Atacado.Repository.Auxiliar;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Auxiliar
{
    public class BancoService : BaseAncestralService<BancoPoco, Banco>
    {
        private BancoMapper mapConfig;
        private BancoRepository repositorio;

        public BancoService()
        {
            this.mapConfig = new BancoMapper();
            this.repositorio = new BancoRepository(new AtacadoContext());
        }

        public override List<BancoPoco> Listar()
        {
            List<Banco> listDom = this.repositorio.Read().ToList();
            return ProcessarListaDOM(listDom);
        }

        public List<BancoPoco> Listar(int pular, int exibir)
        {
            List<Banco> listDom = this.repositorio.Read(pular, exibir).ToList();
            return ProcessarListaDOM(listDom);
        }

        protected override List<BancoPoco> ProcessarListaDOM(List<Banco> listDom)
        {
            return listDom.Select(dom => this.mapConfig.Mapper.Map<BancoPoco>(dom)).ToList();
        }

        public override BancoPoco Selecionar(int id)
        {
            Banco dom = this.repositorio.Read(id);
            BancoPoco poco = this.mapConfig.Mapper.Map<BancoPoco>(dom);
            return poco;
        }

        public override BancoPoco Criar(BancoPoco obj)
        {
            Banco dom = this.mapConfig.Mapper.Map<Banco>(obj);
            Banco criado = this.repositorio.Add(dom);
            BancoPoco poco = this.mapConfig.Mapper.Map<BancoPoco>(criado);
            return poco;
        }

        public override BancoPoco Atualizar(BancoPoco obj)
        {
            Banco dom = this.mapConfig.Mapper.Map<Banco>(obj);
            Banco atualizado = this.repositorio.Edit(dom);
            BancoPoco poco = this.mapConfig.Mapper.Map<BancoPoco>(atualizado);
            return poco;
        }

        public override BancoPoco Excluir(int id)
        {
            Banco excluido = this.repositorio.DeleteById(id);
            BancoPoco poco = this.mapConfig.Mapper.Map<BancoPoco>(excluido);
            return poco;
        }

        public override BancoPoco Excluir(BancoPoco obj)
        {
            return this.Excluir(obj.IdBanco);
        }
    }
}

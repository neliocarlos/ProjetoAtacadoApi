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
    public class AreaConhecimentoService : BaseAncestralService<AreaConhecimentoPoco, AreaConhecimento>
    {
        private AreaConhecimentoMapper mapConfig;
        private AreaConhecimentoRepository repositorio;

        public AreaConhecimentoService()
        { 
            this.mapConfig = new AreaConhecimentoMapper();
            this.repositorio = new AreaConhecimentoRepository(new AtacadoContext());
        }

        public override List<AreaConhecimentoPoco> Listar()
        {
            List<AreaConhecimento> listDom = this.repositorio.Read().ToList();
            return ProcessarListaDOM(listDom);
        }

        public List<AreaConhecimentoPoco> Listar(int pular, int exibir)
        {
            List<AreaConhecimento> listDom = this.repositorio.Read(pular, exibir).ToList();
            return ProcessarListaDOM(listDom);
        }

        protected override List<AreaConhecimentoPoco> ProcessarListaDOM(List<AreaConhecimento> listDom)
        {
            return listDom.Select(dom => this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(dom)).ToList();
        }

        public override AreaConhecimentoPoco Selecionar(int id)
        {
            AreaConhecimento dom = this.repositorio.Read(id);
            AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(dom);
            return poco;
        }

        public override AreaConhecimentoPoco Criar(AreaConhecimentoPoco obj)
        {
            AreaConhecimento dom = this.mapConfig.Mapper.Map<AreaConhecimento>(obj);
            AreaConhecimento criado = this.repositorio.Add(dom);
            AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(criado);
            return poco;
        }

        public override AreaConhecimentoPoco Atualizar(AreaConhecimentoPoco obj)
        {
            AreaConhecimento dom = this.mapConfig.Mapper.Map<AreaConhecimento>(obj);
            AreaConhecimento atualizado = this.repositorio.Edit(dom);
            AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(atualizado);
            return poco;
        }

        public override AreaConhecimentoPoco Excluir(AreaConhecimentoPoco obj)
        {
            return this.Excluir(obj.IdAreaConhecimento);
        }

        public override AreaConhecimentoPoco Excluir(int id)
        {
            AreaConhecimento excluido = this.repositorio.DeleteById(id);
            AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(excluido);
            return poco;
        }
    }
}

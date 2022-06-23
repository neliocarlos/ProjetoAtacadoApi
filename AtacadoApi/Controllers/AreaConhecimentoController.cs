﻿using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaConhecimentoController : ControllerBase
    {
        private AreaConhecimentoService servico;

        public AreaConhecimentoController() : base()
        {
            this.servico = new AreaConhecimentoService();
        }

        [HttpGet("{skip:int}/{take:int}")]
        public List<AreaConhecimentoPoco> GetAll(int skip, int take)
        {
            return this.servico.Listar(skip, take);
        }

        [HttpGet]
        public List<AreaConhecimentoPoco> GetAll()
        {
            return this.servico.Listar();
        }

        [HttpGet("{id:int}")]
        public AreaConhecimentoPoco GetById(int id)
        {
            return this.servico.Selecionar(id);
        }

        [HttpPost]
        public AreaConhecimentoPoco Post([FromBody] AreaConhecimentoPoco poco)
        {
            return this.servico.Criar(poco);
        }

        [HttpPut]
        public AreaConhecimentoPoco Put([FromBody] AreaConhecimentoPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        [HttpDelete]
        public AreaConhecimentoPoco Delete([FromBody] AreaConhecimentoPoco poco)
        {
            return this.servico.Excluir(poco);
        }

        [HttpDelete("{id:int}")]
        public AreaConhecimentoPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}

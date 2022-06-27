using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/auxiliar/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private BancoService servico;

        public BancoController() : base()
        {
            this.servico = new BancoService();
        }

        [HttpGet("{skip:int}/{take:int}")]
        public List<BancoPoco> GetAll(int skip, int take)
        {
            return this.servico.Listar(skip, take);
        }

        [HttpGet]
        public List<BancoPoco> GetAll()
        {
            return this.servico.Listar();
        }

        [HttpGet("{id:int}")]
        public BancoPoco GetById(int id)
        {
            return this.servico.Selecionar(id);
        }

        [HttpPost]
        public BancoPoco Post([FromBody] BancoPoco poco)
        {
            return this.servico.Criar(poco);
        }

        [HttpPut]
        public BancoPoco Put([FromBody] BancoPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        [HttpDelete]
        public BancoPoco Delete([FromBody] BancoPoco poco)
        {
            return this.servico.Excluir(poco);
        }

        [HttpDelete("{id:int}")]
        public BancoPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}

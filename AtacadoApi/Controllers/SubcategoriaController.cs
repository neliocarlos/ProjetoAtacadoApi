using Atacado.Poco.Estoque;
using Atacado.Service.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {
        private SubcategoriaService servico;

        public SubcategoriaController() : base()
        {
            this.servico = new SubcategoriaService();
        }

        [HttpGet("{skip:int}/{take:int}")]
        public List<SubcategoriaPoco> GetAll(int skip, int take)
        {
            return this.servico.Listar(skip, take);
        }

        [HttpGet]
        public List<SubcategoriaPoco> GetAll()
        {
            return this.servico.Listar();
        }

        [HttpGet("{id:int}")]
        public SubcategoriaPoco GetById(int id)
        {
            return this.servico.Selecionar(id);
        }

        [HttpPost]
        public SubcategoriaPoco Post([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Criar(poco);
        }

        [HttpPut]
        public SubcategoriaPoco Put([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        [HttpDelete]
        public SubcategoriaPoco Delete([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Excluir(poco);
        }

        [HttpDelete("{id:int}")]
        public SubcategoriaPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}
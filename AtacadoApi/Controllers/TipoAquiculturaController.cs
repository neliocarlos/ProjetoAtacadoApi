using Atacado.Envelope.Auxiliar;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// Recurso TipoTipoAquicultura.
    /// </summary>
    [Route("api/auxiliar/[controller]")]
    [ApiController]
    public class TipoAquiculturaController : ControllerBase
    {
        private TipoAquiculturaService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public TipoAquiculturaController() : base()
        {
            this.servico = new TipoAquiculturaService();
        }

        /// <summary>
        /// Realiza a busca por todos os registros, filtrando por onde iniciar(skip), e a quantidade desejada(take).
        /// </summary>
        /// <param name="skip">Onde inicia os resultados.</param>
        /// <param name="take">Quantos registros serão retornados.</param>
        /// <returns>Coleção de dados.</returns>
        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<TipoAquiculturaEnvelopeJSON>> GetList(int skip, int take)
        {
            try
            {
                List<TipoAquiculturaEnvelopeJSON> lista = this.servico.Listar(skip, take);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Realiza a busca pelo ID do registro desejado.
        /// </summary>
        /// <param name="id">Informe o ID desejado.</param>
        /// <returns>Registro.</returns>
        [HttpGet("{id:int}")]
        public ActionResult<TipoAquiculturaEnvelopeJSON> GetById(int id)
        {
            try
            {
                TipoAquiculturaEnvelopeJSON poco = this.servico.Selecionar(id);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Realiza a criação de um novo registro.
        /// </summary>
        /// <param name="poco">Dados do novo registro.</param>
        /// <returns>Novo registro.</returns>
        [HttpPost]
        public ActionResult<TipoAquiculturaEnvelopeJSON> Post([FromBody] TipoAquiculturaPoco poco)
        {
            try
            {
                TipoAquiculturaEnvelopeJSON add = this.servico.Criar(poco);
                return Ok(add);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Atualiza os dados de um registro.
        /// </summary>
        /// <param name="poco">Registro a ser atualizado.</param>
        /// <returns>Registro atualizado.</returns>
        [HttpPut]
        public ActionResult<TipoAquiculturaEnvelopeJSON> Put([FromBody] TipoAquiculturaPoco poco)
        {
            try
            {
                TipoAquiculturaEnvelopeJSON updt = this.servico.Atualizar(poco);
                return Ok(updt);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Exclui determinado registro.
        /// </summary>
        /// <param name="poco">Registro a ser excluído.</param>
        /// <returns>Registro excluído.</returns>
        [HttpDelete]
        public ActionResult<TipoAquiculturaEnvelopeJSON> Delete([FromBody] TipoAquiculturaPoco poco)
        {
            try
            {
                TipoAquiculturaEnvelopeJSON delete = this.servico.Excluir(poco);
                return Ok(delete);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Exclui determinado registro, filtrado por sua ID. 
        /// </summary>
        /// <param name="id">Informar ID do registro.</param>
        /// <returns>Registro excluído.</returns>
        [HttpDelete("{id:int}")]
        public ActionResult<TipoAquiculturaEnvelopeJSON> DeleteById(int id)
        {
            try
            {
                TipoAquiculturaEnvelopeJSON delete = this.servico.Excluir(id);
                return Ok(delete);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}

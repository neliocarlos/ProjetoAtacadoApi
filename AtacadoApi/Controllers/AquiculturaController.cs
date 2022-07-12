using Atacado.EF.Database;
using Atacado.Envelope.Auxiliar;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// Recurso Aquicultura.
    /// </summary>
    [Route("api/auxiliar/[controller]")]
    [ApiController]
    public class AquiculturaController : ControllerBase
    {
        private AquiculturaService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public AquiculturaController(AtacadoContext contexto) : base()
        {
            this.servico = new AquiculturaService(contexto);
        }

        /// <summary>
        /// Realiza a busca por todos os registros, filtrando por onde iniciar(skip), e a quantidade desejada(take).
        /// </summary>
        /// <param name="skip">Onde inicia os resultados.</param>
        /// <param name="take">Quantos registros serão retornados.</param>
        /// <returns>Coleção de dados.</returns>
        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<AquiculturaEnvelopeJSON>> GetList(int skip, int take)
        {
            try
            {
                List<AquiculturaEnvelopeJSON> lista = this.servico.Listar(skip, take);
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
        public ActionResult<AquiculturaEnvelopeJSON> GetById(int id)
        {
            try
            {
                AquiculturaEnvelopeJSON poco = this.servico.Selecionar(id);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Realiza uma busca por todos os registros, filtrando pelo ano(ano) e pelo ID do município(idMun).
        /// </summary>
        /// <param name="ano">Ano desejado.</param>
        /// <param name="idMun">ID do município desejado.</param>
        /// <returns>Coleção de dados.</returns>
        [HttpGet("ano/{ano:int}/idmun/{idMun:int}")]
        public ActionResult<List<AquiculturaEnvelopeJSON>> GetPorAnoIdMun(int ano, int idMun)
        {
            try
            {
                List<AquiculturaEnvelopeJSON> lista = this.servico.FiltrarPorAnoIdMun(ano, idMun);
                return Ok(lista);
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
        public ActionResult<AquiculturaEnvelopeJSON> Post([FromBody] AquiculturaPoco poco)
        {
            try
            {
                AquiculturaEnvelopeJSON add = this.servico.Criar(poco);
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
        public ActionResult<AquiculturaEnvelopeJSON> Put([FromBody] AquiculturaPoco poco)
        {
            try
            {
                AquiculturaEnvelopeJSON updt = this.servico.Atualizar(poco);
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
        public ActionResult<AquiculturaEnvelopeJSON> Delete([FromBody] AquiculturaPoco poco)
        {
            try
            {
                AquiculturaEnvelopeJSON delete = this.servico.Excluir(poco);
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
        public ActionResult<AquiculturaEnvelopeJSON> DeleteById(int id)
        {
            try
            {
                AquiculturaEnvelopeJSON delete = this.servico.Excluir(id);
                return Ok(delete);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}

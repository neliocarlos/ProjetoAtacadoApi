using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// Recurso Rebanho.
    /// </summary>
    [Route("api/auxiliar/[controller]")]
    [ApiController]
    public class RebanhoController : ControllerBase
    {
        private RebanhoService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public RebanhoController()
        {
            this.servico = new RebanhoService();
        }

        /// <summary>
        /// Realiza a busca por todos os registros, filtrando por onde iniciar(skip) e a quantidade desejada(take).
        /// </summary>
        /// <param name="skip">Onde inicia os resultados.</param>
        /// <param name="take">Quantos registros serão retornados.</param>
        /// <returns>Coleção de dados.</returns>
        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<RebanhoPoco>> Get(int skip, int take)
        {
            try
            {
                List<RebanhoPoco> lista = this.servico.Listar(skip, take);
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
        /// <param name="id">Informar o ID desejado.</param>
        /// <returns>Registro.</returns>
        [HttpGet("{id:int}")]
        public ActionResult<RebanhoPoco> GetPorID(int id)
        {
            try
            {
                RebanhoPoco resposta = this.servico.Selecionar(id);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Realiza uma busca por todos os registros, filtrando pelo ano(anoRef) e pelo ID do município(idMun).
        /// </summary>
        /// <param name="anoRef">Informar o ano de referência.</param>
        /// <param name="idMun">Informar o ID do município.</param>
        /// <returns>Coleção de dados.</returns>
        [HttpGet("anoref/{anoRef:int}/idmun/{idMun:int}")]
        public ActionResult<List<RebanhoPoco>> GetPorAnoRefIdMun(int anoRef, int idMun)
        {
            try
            {
                List<RebanhoPoco> lista = this.servico.FiltrarPorAnoRefIdMun(anoRef, idMun);
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
        public ActionResult<RebanhoPoco> Post([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco resposta = this.servico.Criar(poco);
                return Ok(resposta);
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
        public ActionResult<RebanhoPoco> Put([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco resposta = this.servico.Atualizar(poco);
                return Ok(resposta);
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
        public ActionResult<RebanhoPoco> Delete([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco resposta = this.servico.Excluir(poco);
                return Ok(resposta);
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
        public ActionResult<RebanhoPoco> DeleteById(int id)
        {
            try
            {
                RebanhoPoco resposta = this.servico.Excluir(id);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}

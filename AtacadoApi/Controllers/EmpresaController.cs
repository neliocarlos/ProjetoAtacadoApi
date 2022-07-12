﻿using Atacado.EF.Database;
using Atacado.Envelope.RH;
using Atacado.Poco.RH;
using Atacado.Service.RH;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// Recurso Empresa.
    /// </summary>
    [Route("api/rh/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private EmpresaService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public EmpresaController(AtacadoContext contexto) : base()
        {
            this.servico = new EmpresaService(contexto);
        }

        /// <summary>
        /// Realiza a busca por todos os registros.
        /// </summary>
        /// <returns>Coleção de dados.</returns>
        [HttpGet]
        public ActionResult<List<EmpresaEnvelopeJSON>> GetAll()
        {
            try
            {
                List<EmpresaEnvelopeJSON> lista = this.servico.Listar();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Realiza a busca por todos os registros, filtrando por onde inicia(skip) e a quantidade(take).
        /// </summary>
        /// <param name="skip">Onde inicia os resultados da pesquisa.</param>
        /// <param name="take">Quantos registros serão retornados.</param>
        /// <returns>Coleção de dados.</returns>
        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<EmpresaEnvelopeJSON>> GetPage(int skip, int take)
        {
            try
            {
                List<EmpresaEnvelopeJSON> lista = this.servico.Listar(skip, take);
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
        /// <param name="id">Onde se informa o ID do registro.</param>
        /// <returns>Registro pesquisado.</returns>
        [HttpGet("{id:int}")]
        public ActionResult<EmpresaEnvelopeJSON> GetById(int id)
        {
            try
            {
                EmpresaEnvelopeJSON json = this.servico.Selecionar(id);
                return Ok(json);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Realiza a adição de um novo registro.
        /// </summary>
        /// <param name="poco">Dados do novo registro.</param>
        /// <returns>Novo registro.</returns>
        [HttpPost]
        public ActionResult<EmpresaEnvelopeJSON> Post([FromBody] EmpresaPoco poco)
        {
            try
            {
                EmpresaEnvelopeJSON json = this.servico.Criar(poco);
                return Ok(json);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Realiza a atualização de um registro.
        /// </summary>
        /// <param name="poco">Dados atualizados do registro.</param>
        /// <returns>Registro atualizado</returns>
        [HttpPut]
        public ActionResult<EmpresaEnvelopeJSON> Put([FromBody] EmpresaPoco poco)
        {
            try
            {
                EmpresaEnvelopeJSON json = this.servico.Atualizar(poco);
                return Ok(json);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro.
        /// </summary>
        /// <param name="poco">Dados do registro a ser excluído.</param>
        /// <returns>Registro excluído.</returns>
        [HttpDelete]
        public ActionResult<EmpresaEnvelopeJSON> Delete([FromBody] EmpresaPoco poco)
        {
            try
            {
                EmpresaEnvelopeJSON json = this.servico.Excluir(poco);
                return Ok(json);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro pelo seu ID.
        /// </summary>
        /// <param name="id">ID do registro.</param>
        /// <returns>Registro excluído.</returns>
        [HttpDelete("{id:int}")]
        public ActionResult<EmpresaEnvelopeJSON> Delete(int id)
        {
            try
            {
                EmpresaEnvelopeJSON json = this.servico.Excluir(id);
                return Ok(json);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}

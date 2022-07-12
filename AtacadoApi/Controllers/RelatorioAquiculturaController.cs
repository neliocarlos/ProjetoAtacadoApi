using Atacado.EF.Database;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// Recurso Relatório Aquicultura.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioAquiculturaController : ControllerBase
    {
        private RelatorioAquiculturaService servico;

        /// <summary>
        /// Construtor da base.
        /// </summary>
        public RelatorioAquiculturaController() : base()
        {
            this.servico = new RelatorioAquiculturaService();
        }

        /// <summary>
        /// Relatório de busca, filtrando por produção não nula, ID do município(id) e ano(ano)
        /// </summary>
        /// <param name="id">ID do município desejado.</param>
        /// <param name="ano">Ano desejado.</param>
        /// <returns>Lista de registros.</returns>
        [HttpGet("idmunicipio/{id:int}/ano/{ano:int}")]
        public ActionResult<List<RelatorioAquiculturaPoco>> GetPorIdMunAno(int id, int ano)
        {
            try
            {
                List<RelatorioAquiculturaPoco> lista = this.servico.RegistrosPorMunicipioAno(id, ano);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Relatório de busca, filtrando por ID de município(idMun), ID do tipo de aquicultura(idTipo) e ano(ano).
        /// </summary>
        /// <param name="idMun">ID do município desejado.</param>
        /// <param name="idTipo">ID do tipo de aquicultura desejada.</param>
        /// <param name="ano">Ano desejado.</param>
        /// <returns>Lista de registros.</returns>
        [HttpGet("idmunicipio/{idMun:int}/idtipo/{idTipo:int}/ano/{ano:int}")]
        public ActionResult<List<RelatorioAquiculturaPoco>> GetPorIdMunIdTipoAno(int idMun, int idTipo, int ano)
        {
            try
            {
                List<RelatorioAquiculturaPoco> lista = this.servico.RegistrosPorMunicipioTipoAquiculturaAno(idMun, idTipo, ano);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}

using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReworkRelatorioController : ControllerBase
    {
        private RelatorioService servico;

        /// <summary>
        /// 
        /// </summary>
        public ReworkRelatorioController() : base()
        {
            this.servico = new RelatorioService();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("produto/porId/{id:int}")]
        public ActionResult<RelatorioPoco> GetProdutoByID(int id)
        {
            try
            {
                RelatorioPoco ficha = this.servico.ProdutoPorID(id);
                return Ok(ficha);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("subcategoria/porId/{id:int}")]
        public ActionResult<List<RelatorioPoco>> GetSubcategoriaByID(int id)
        {
            try
            {
                List<RelatorioPoco> lista = this.servico.SubcategoriaPorID(id);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("categoria/porId/{id:int}")]
        public ActionResult<List<RelatorioPoco>> GetCategoriaByID(int id)
        {
            try
            {
                List<RelatorioPoco> lista = this.servico.CategoriaPorID(id);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}

using Atacado.EF.Database;
using Atacado.Poco.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private AtacadoContext contexto;

        public RelatorioController() : base()
        {
            this.contexto = new AtacadoContext();
        }

        [HttpGet("fichacadastral/{idRebanho:int}")]
        public ActionResult<object> Get(int idRebanho)
        {
            try
            {
                var retorno = 
                    from rebs in contexto.Rebanhos
                    where rebs.IdRebanho == idRebanho
                    join muns in contexto.Municipios on rebs.IdMunicipio equals muns.CodigoIbge7
                    join ufs in contexto.UnidadeFederacaos on muns.SiglaUf equals ufs.SiglaUf
                    select new
                    {
                        IdRebanho = rebs.IdRebanho,
                        AnoReferencia = rebs.AnoRef,
                        IdMunicipio = rebs.IdMunicipio,
                        NomeMunicipio = muns.NomeMunicipio,
                        SiglaUf = ufs.SiglaUf,
                        NomeEstado = ufs.DescricaoUnidadeFederacao,
                        IdTipoRebanho = rebs.IdTipoRebanho,
                        NomeRebanho = rebs.TipoRebanho,
                        Quantidade = rebs.Quantidade,
                        Situacao = rebs.Situacao
                    };
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("listaAnoRefIbge7/{anoRef:int}/{idMun:int}")]
        public ActionResult<List<Object>> GetList(int anoRef, int idMun)
        {
            try
            {
                var retorno =
                         from rebs in contexto.Rebanhos
                         where (rebs.AnoRef == anoRef) && (rebs.IdMunicipio == idMun)
                         join muns in contexto.Municipios on rebs.IdMunicipio equals muns.CodigoIbge7
                         join ufs in contexto.UnidadeFederacaos on muns.SiglaUf equals ufs.SiglaUf
                         select new
                         {
                             IdRebanho = rebs.IdRebanho,
                             AnoReferencia = rebs.AnoRef,
                             IdMunicipio = rebs.IdMunicipio,
                             NomeMunicipio = muns.NomeMunicipio,
                             SiglaUf = ufs.SiglaUf,
                             NomeEstado = ufs.DescricaoUnidadeFederacao,
                             IdTipoRebanho = rebs.IdTipoRebanho,
                             NomeRebanho = rebs.TipoRebanho,
                             Quantidade = rebs.Quantidade,
                             Situacao = rebs.Situacao
                         };
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("listacategoria/{id:int}")]
        public ActionResult<List<Object>> GetListCategoriaById(int id)
        {
            try
            {
                var retorno =
                        from cats in contexto.Categorias
                        where cats.IdCategoria == id
                        join subs in contexto.Subcategorias on cats.IdCategoria equals subs.IdCategoria
                        join prods in contexto.Produtos on subs.IdSubcategoria equals prods.IdSubcategoria
                        select new
                        {
                            IdCategoria = cats.IdCategoria,
                            NomeCategoria = cats.DescricaoCategoria,
                            IdSubcategoria = subs.IdSubcategoria,
                            NomeSubcategoria = subs.DescricaoSubcategoria,
                            IdProduto = prods.IdProduto,
                            NomeProduto = prods.DescricaoProduto
                        };
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("listasubcategoria/{id:int}")]
        public ActionResult<List<Object>> GetListSubcategoriaById(int id)
        {
            try
            {
                var retorno =
                        from subs in contexto.Subcategorias
                        where subs.IdSubcategoria == id
                        join cats in contexto.Categorias on subs.IdCategoria equals cats.IdCategoria
                        join prods in contexto.Produtos on subs.IdSubcategoria equals prods.IdSubcategoria
                        select new
                        {
                            IdSubcategoria = subs.IdSubcategoria,
                            NomeSubcategoria = subs.DescricaoSubcategoria,
                            IdCategoria = cats.IdCategoria,
                            NomeCategoria = cats.DescricaoCategoria,
                            IdProduto = prods.IdProduto,
                            NomeProduto = prods.DescricaoProduto
                        };
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("fichaproduto/{id:int}")]
        public ActionResult<Object> GetProdutoById(int id)
        {
            try
            {
                var retorno =
                        from prods in contexto.Produtos
                        where prods.IdProduto == id
                        join cats in contexto.Categorias on prods.IdCategoria equals cats.IdCategoria
                        join subs in contexto.Subcategorias on prods.IdSubcategoria equals subs.IdSubcategoria
                        select new
                        {
                            IdProduto = prods.IdProduto,
                            NomeProduto = prods.DescricaoProduto,
                            IdSubcategoria = subs.IdSubcategoria,
                            NomeSubcategoria = subs.DescricaoSubcategoria,
                            IdCategoria = cats.IdCategoria,
                            NomeCategoria = cats.DescricaoCategoria
                        };
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}

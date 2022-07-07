using Atacado.EF.Database;
using Atacado.Poco.Estoque;
using Atacado.Repository.Estoque;
using Atacado.Service.Ancestral;
using AtacadoApi.Controllers;
using Atacado.Mapper.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Auxiliar
{
    public class RelatorioService
    {
        private AtacadoContext contexto;

        public RelatorioService()
        {
            this.contexto = new AtacadoContext();
        }

        public RelatorioPoco ProdutoPorID(int id)
        {
            RelatorioPoco ficha =
                (from prods in this.contexto.Produtos
                 join cats in this.contexto.Categorias on prods.IdCategoria equals cats.IdCategoria
                 join subs in this.contexto.Subcategorias on prods.IdSubcategoria equals subs.IdSubcategoria
                 where prods.IdProduto == id                 
                 select new RelatorioPoco()
                 {
                     IdProduto = prods.IdProduto,
                     DescricaoProduto = prods.DescricaoProduto,
                     IdSubcategoria = subs.IdSubcategoria,
                     DescricaoSubcategoria = subs.DescricaoSubcategoria,
                     IdCategoria = cats.IdCategoria,
                     DescricaoCategoria = cats.DescricaoCategoria
                 }).Single();
            return ficha;
        }      
        
        public List<RelatorioPoco> SubcategoriaPorID(int id)
        {
            List<RelatorioPoco> lista =
                (from subs in this.contexto.Subcategorias
                where subs.IdSubcategoria == id
                join cats in this.contexto.Categorias on subs.IdCategoria equals cats.IdCategoria
                join prods in this.contexto.Produtos on subs.IdSubcategoria equals prods.IdSubcategoria
                select new RelatorioPoco()
                {
                    IdSubcategoria = subs.IdSubcategoria,
                    DescricaoSubcategoria = subs.DescricaoSubcategoria,
                    IdCategoria = cats.IdCategoria,
                    DescricaoCategoria = cats.DescricaoCategoria,
                    IdProduto = prods.IdProduto,
                    DescricaoProduto = prods.DescricaoProduto
                }).ToList();
            return lista;
        }

        public List<RelatorioPoco> CategoriaPorID(int id)
        {
            List<RelatorioPoco> lista =
                (from cats in this.contexto.Categorias
                 where cats.IdCategoria == id
                 join subs in this.contexto.Subcategorias on cats.IdCategoria equals subs.IdCategoria
                 join prods in this.contexto.Produtos on subs.IdSubcategoria equals prods.IdSubcategoria
                 select new RelatorioPoco()
                 {
                     IdCategoria = cats.IdCategoria,
                     DescricaoCategoria = cats.DescricaoCategoria,
                     IdSubcategoria = subs.IdSubcategoria,
                     DescricaoSubcategoria = subs.DescricaoSubcategoria,
                     IdProduto = prods.IdProduto,
                     DescricaoProduto = prods.DescricaoProduto
                 }).ToList();
            return lista;
        }
    }
}

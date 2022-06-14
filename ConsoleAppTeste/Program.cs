﻿using Atacado.Service.Estoque;
using Atacado.Poco.Estoque;
using Atacado.EF.Database;
using ConsoleAppTeste.Teste;

namespace ConsoleAppTeste
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //TestarCategoria();
            //TestarSubcategoria();
            TestarProduto();
            Console.ReadLine();
        }

        private static void TestarCategoria()
        {
            CategoriaTeste teste = new CategoriaTeste();
            teste.Executar();
        }

        private static void TestarSubcategoria()
        {
            SubcategoriaTeste teste = new SubcategoriaTeste();
            teste.Executar();
        }

        private static void TestarProduto()
        {
            ProdutoTeste teste = new ProdutoTeste();
            teste.Executar();
        }
    }
}
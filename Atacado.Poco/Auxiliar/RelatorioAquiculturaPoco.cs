namespace Atacado.Poco.Auxiliar
{
    public class RelatorioAquiculturaPoco
    {
        public int IdMunicipio { get; set; }

        public int Ano { get; set; }

        public string NomeTipoAquicultura { get; set; }

        public string NomeMunicipio { get; set; }

        public string SiglaUf { get; set; }

        public string DescricaoUnidadeFederacao { get; set; }

        public int IdAquicultura { get; set; }

        public int IdTipoAquicultura { get; set; }

        public int? Producao { get; set; }

        public int? ValorProducao { get; set; }

        public double? ProporcaoValorProducao { get; set; }

        public string Moeda { get; set; }
    }
}

﻿namespace Atacado.Poco.Auxiliar
{
    public class BancoPoco
    {
        public int IdBanco { get; set; }

        public int? CodigoBanco { get; set; }

        public string DescricaoBanco { get; set; } = null!;

        public string? SiteBanco { get; set; }

        public bool? Situacao { get; set; }
    }
}

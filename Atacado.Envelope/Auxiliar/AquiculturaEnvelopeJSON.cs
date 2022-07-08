﻿using Atacado.Envelope.Ancestral;
using Newtonsoft.Json;

namespace Atacado.Envelope.Auxiliar
{
    public class AquiculturaEnvelopeJSON : BaseEnvelopeJSON
    {
        [JsonProperty(PropertyName = "id")]
        public int IdAquicultura { get; set; }

        [JsonProperty(PropertyName = "ano")]
        public int Ano { get; set; }

        [JsonProperty(PropertyName = "idmunicipio")]
        public int IdMunicipio { get; set; }

        [JsonProperty(PropertyName = "idtipo")]
        public int IdTipoAquicultura { get; set; }

        [JsonProperty(PropertyName = "producao")]
        public int? Producao { get; set; }

        [JsonProperty(PropertyName = "valor")]
        public int? ValorProducao { get; set; }

        [JsonProperty(PropertyName = "proporcaovalor")]
        public double? ProporcaoValorProducao { get; set; }

        [JsonProperty(PropertyName = "moeda")]
        public string Moeda { get; set; }

        public override void SetLinks()
        {
            this.Links.List = "GET /aquicultura";
            this.Links.Self = "GET /aquicultura/" + this.IdAquicultura.ToString();
            this.Links.Exclude = "DELETE /aquicultura/" + this.IdAquicultura.ToString();
            this.Links.Update = "PUT /aquicultura";
            this.Links.Create = "POST /aquicultura";
        }
    }
}

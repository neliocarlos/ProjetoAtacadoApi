using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.EF.Database
{
    [Table("Aquicultura")]
    public class Aquicultura
    {
        [Key]
        [Column("Id_Aquicultura")]
        public int IdAquicultura { get; set; }

        public int Ano { get; set; }

        [Column("Id_Municipio")]
        public int IdMunicipio { get; set; }

        [Column("Id_Tipo_Aquicultura")]
        public int IdTipoAquicultura { get; set; }

        public int? Producao { get; set; }

        [Column("Valor_Producao")]
        public int? ValorProducao { get; set; }

        [Column("Proporcao_Valor_Producao")]
        public double? ProporcaoValorProducao { get; set; }

        [Unicode(false)]
        public string Moeda { get; set; }

        public bool? Situacao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
    }
}

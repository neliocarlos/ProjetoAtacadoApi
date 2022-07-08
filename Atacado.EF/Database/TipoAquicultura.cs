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
    [Table("Tipo_Aquicultura")]
    public class TipoAquicultura
    {
        [Key]
        [Column("Id_Tipo_Aquicultura")]
        public int IdTipoAquicultura { get; set; }

        [Column("Descricao_Tipo_Aquicultura")]
        [Unicode(false)]
        public string NomeTipoAquicultura { get; set; }

        public bool? Situacao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
    }
}

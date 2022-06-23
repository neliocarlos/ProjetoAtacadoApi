﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Table("Tipo_Rebanho")]
    public partial class TipoRebanho
    {
        [Key]
        [Column("ID_Tipo")]
        public int IdTipo { get; set; }
        
        [Column("Descricao")]
        [Unicode(false)]
        public string Descricao { get; set; }

        public bool? Situacao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
    }
}

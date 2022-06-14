﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Table("Idioma")]
    public partial class Idioma
    {
        [Key]
        [Column("ID_Idioma")]
        public int IdIdioma { get; set; }
        [Column("Abreviacao_Idioma")]
        [StringLength(2)]
        [Unicode(false)]
        public string AbreviacaoIdioma { get; set; } = null!;
        [Column("Descricao_Idioma")]
        [Unicode(false)]
        public string DescricaoIdioma { get; set; } = null!;
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
    }
}

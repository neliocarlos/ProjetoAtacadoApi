﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Keyless]
    public partial class VwInformacaoProduto
    {
        [Column("ID_Categoria")]
        public int IdCategoria { get; set; }
        [Column("ID_Subcategoria")]
        public int IdSubcategoria { get; set; }
        [Column("Descricao_Categoria")]
        [Unicode(false)]
        public string DescricaoCategoria { get; set; } = null!;
        [Column("Descricao_Subcategoria")]
        [Unicode(false)]
        public string DescricaoSubcategoria { get; set; } = null!;
        [Column("ID_Produto")]
        public int IdProduto { get; set; }
        [Column("Descricao_Produto")]
        [Unicode(false)]
        public string DescricaoProduto { get; set; } = null!;
    }
}

﻿using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.Auxiliar
{
    public class ProfissaoRepository : BaseRepository<Profissao>
    {
        public ProfissaoRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override Profissao DeleteById(int id)
        {
            Profissao profissao = this.Read(id);
            this.context.Set<Profissao>().Remove(profissao);
            this.context.SaveChanges();
            return profissao;
        }
    }
}

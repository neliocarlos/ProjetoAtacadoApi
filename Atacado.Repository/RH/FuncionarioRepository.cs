﻿using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.RH
{
    public class FuncionarioRepository : BaseRepository<Funcionario>
    {
        public FuncionarioRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override Funcionario DeleteById(int id)
        {
            Funcionario funcionario = this.Read(id);
            this.context.Set<Funcionario>().Remove(funcionario);
            this.context.SaveChanges();
            return funcionario;
        }
    }
}

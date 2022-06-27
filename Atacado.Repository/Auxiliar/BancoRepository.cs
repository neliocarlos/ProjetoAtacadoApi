﻿using Atacado.Repository.Ancestral;
using Atacado.EF.Database;

namespace Atacado.Repository.Auxiliar
{
    public class BancoRepository : BaseRepository<Banco>
    {
        public BancoRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override Banco DeleteById(int id)
        {
            Banco banco = this.Read(id);
            this.context.Set<Banco>().Remove(banco);
            this.context.SaveChanges();
            return banco;
        }
    }
}

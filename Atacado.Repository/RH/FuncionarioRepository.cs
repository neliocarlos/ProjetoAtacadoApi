using Atacado.EF.Database;
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
            Funcionario del = this.Read(id);
            this.context.Set<Funcionario>().Remove(del);
            this.context.SaveChanges();
            return del;
        }

        public override Funcionario Read(int id)
        {
            return this.context.Set<Funcionario>().Find(Convert.ToInt64(id));
        }
    }
}

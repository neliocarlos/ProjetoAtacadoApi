using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.RH
{
    public class EmpresaRepository : BaseRepository<Empresa>
    {
        public EmpresaRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override Empresa DeleteById(int id)
        {
            Empresa del = this.Read(id);
            this.context.Set<Empresa>().Remove(del);
            this.context.SaveChanges();
            return del;
        }
    }
}

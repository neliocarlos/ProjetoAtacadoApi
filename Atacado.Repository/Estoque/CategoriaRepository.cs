using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.Estoque
{
    public class CategoriaRepository : BaseRepository<Categoria>
    {
        public CategoriaRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override Categoria DeleteById(int id)
        {
            Categoria categoria = this.Read(id);
            this.context.Set<Categoria>().Remove(categoria);
            this.context.SaveChanges();
            return categoria;
        }
    }
}

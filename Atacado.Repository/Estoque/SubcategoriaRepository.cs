using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.Estoque
{
    public class SubcategoriaRepository : BaseRepository<Subcategoria>
    {
        public SubcategoriaRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override Subcategoria DeleteById(int id)
        {
            Subcategoria subcategoria = this.Read(id);
            this.context.Set<Subcategoria>().Remove(subcategoria);
            this.context.SaveChanges();
            return subcategoria;
        }
    }
}

using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.Auxiliar
{
    public class AreaConhecimentoRepository : BaseRepository<AreaConhecimento>
    {
        public AreaConhecimentoRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override AreaConhecimento DeleteById(int id)
        {
            AreaConhecimento areaConhecimento = this.Read(id);
            this.context.Set<AreaConhecimento>().Remove(areaConhecimento);
            this.context.SaveChanges();
            return areaConhecimento;
        }
    }
}

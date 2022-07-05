using Atacado.Mapper.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Ancestral
{
    public abstract class BaseEnvelopadaService<TPoco, TDom, TEnvelope>
        where TPoco : class
        where TDom : class
        where TEnvelope : class
    {
        protected MapeadorGenericoEnvelopado<TPoco, TDom, TEnvelope> mapeador;
        protected List<string> mensagensProcess;

        public List<string> MensagensProcess => this.mensagensProcess;

        public BaseEnvelopadaService()
        {
            this.mensagensProcess = new List<string>();
        }

        public virtual List<TEnvelope> Listar()
        {
            throw new NotImplementedException("Faz ai preguiça!");
        }

        public virtual TEnvelope Selecionar(int id)
        {
            throw new NotSupportedException("Faz ai preguiça!");
        }

        public virtual TEnvelope Criar(TPoco obj)
        {
            throw new NotSupportedException("Faz ai preguiça!");
        }

        public virtual TEnvelope Atualizar(TPoco obj)
        {
            throw new NotSupportedException("Faz ai preguiça!");
        }

        public virtual TEnvelope Excluir(TPoco obj)
        {
            throw new NotSupportedException("Faz ai preguiça!");
        }

        public virtual TEnvelope Excluir(int id)
        {
            throw new NotSupportedException("Faz ai preguiça!");
        }

        protected virtual List<TEnvelope> ProcessarListaDOM(List<TDom> listDom)
        {
            throw new NotImplementedException("Faz ai preguiça!");
        }
    }
}

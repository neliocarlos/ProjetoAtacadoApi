using Atacado.EF.Database;
using Atacado.Envelope.Auxiliar;
using Atacado.Mapper.Ancestral;
using Atacado.Poco.Auxiliar;
using Atacado.Repository.Auxiliar;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Auxiliar
{
    public class TipoAquiculturaService : BaseEnvelopadaService<TipoAquiculturaPoco, TipoAquicultura, TipoAquiculturaEnvelopeJSON>
    {
        private TipoAquiculturaRepository repositorio;

        public TipoAquiculturaService() : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<TipoAquiculturaPoco, TipoAquicultura, TipoAquiculturaEnvelopeJSON>();
            this.repositorio = new TipoAquiculturaRepository(new AtacadoContext());
        }

        public TipoAquiculturaService(AtacadoContext contexto) : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<TipoAquiculturaPoco, TipoAquicultura, TipoAquiculturaEnvelopeJSON>();
            this.repositorio = new TipoAquiculturaRepository(contexto);
        }

        public override List<TipoAquiculturaEnvelopeJSON> Listar()
        {
            List<TipoAquicultura> lista = this.repositorio.Read().ToList();
            return ProcessarListaDOM(lista);
        }

        public List<TipoAquiculturaEnvelopeJSON> Listar(int skip, int take)
        {
            List<TipoAquicultura> lista = this.repositorio.Read(skip, take).ToList();
            return ProcessarListaDOM(lista);
        }

        protected override List<TipoAquiculturaEnvelopeJSON> ProcessarListaDOM(List<TipoAquicultura> listDom)
        {
            return listDom.Select(dom => this.mapeador.Mecanismo.Map<TipoAquiculturaEnvelopeJSON>(dom)).ToList();
        }

        public override TipoAquiculturaEnvelopeJSON Selecionar(int id)
        {
            TipoAquicultura dom = this.repositorio.Read(id);
            TipoAquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<TipoAquiculturaEnvelopeJSON>(dom);
            json.SetLinks();
            return json;
        }

        public override TipoAquiculturaEnvelopeJSON Criar(TipoAquiculturaPoco obj)
        {
            TipoAquicultura criado = this.mapeador.Mecanismo.Map<TipoAquicultura>(obj);
            TipoAquicultura dom = this.repositorio.Add(criado);
            TipoAquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<TipoAquiculturaEnvelopeJSON>(dom);
            json.SetLinks();
            return json;
        }

        public override TipoAquiculturaEnvelopeJSON Atualizar(TipoAquiculturaPoco obj)
        {
            TipoAquicultura dom = this.mapeador.Mecanismo.Map<TipoAquicultura>(obj);
            TipoAquicultura atualizado = this.repositorio.Edit(dom);
            TipoAquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<TipoAquiculturaEnvelopeJSON>(atualizado);
            json.SetLinks();
            return json;
        }

        public override TipoAquiculturaEnvelopeJSON Excluir(int id)
        {
            TipoAquicultura excluido = this.repositorio.DeleteById(id);
            TipoAquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<TipoAquiculturaEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }

        public override TipoAquiculturaEnvelopeJSON Excluir(TipoAquiculturaPoco obj)
        {
            return this.Excluir(obj.IdTipoAquicultura);
        }
    }
}

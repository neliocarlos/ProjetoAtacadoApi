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
    public class AquiculturaService : BaseEnvelopadaService<AquiculturaPoco, Aquicultura, AquiculturaEnvelopeJSON>
    {
        private AquiculturaRepository repositorio;

        public AquiculturaService() : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<AquiculturaPoco, Aquicultura, AquiculturaEnvelopeJSON>();
            this.repositorio = new AquiculturaRepository(new AtacadoContext());
        }

        public List<AquiculturaEnvelopeJSON> Listar(int skip, int take)
        {
            List<Aquicultura> lista = this.repositorio.Read(skip, take).ToList();
            return ProcessarListaDOM(lista);
        }

        public List<AquiculturaEnvelopeJSON> FiltrarPorAnoIdMun(int ano, int idMun)
        {
            List<Aquicultura> listDom =
                this.repositorio.Browse(reb => (reb.Ano == ano) && (reb.IdMunicipio == idMun)).ToList();
            return ProcessarListaDOM(listDom);
        }

        protected override List<AquiculturaEnvelopeJSON> ProcessarListaDOM(List<Aquicultura> listDom)
        {
            return listDom.Select(dom => this.mapeador.Mecanismo.Map<AquiculturaEnvelopeJSON>(dom)).ToList();
        }

        public override AquiculturaEnvelopeJSON Selecionar(int id)
        {
            Aquicultura dom = this.repositorio.Read(id);
            AquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<AquiculturaEnvelopeJSON>(dom);
            json.SetLinks();
            return json;
        }

        public override AquiculturaEnvelopeJSON Criar(AquiculturaPoco obj)
        {
            Aquicultura criado = this.mapeador.Mecanismo.Map<Aquicultura>(obj);
            Aquicultura dom = this.repositorio.Add(criado);
            AquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<AquiculturaEnvelopeJSON>(dom);
            json.SetLinks();
            return json;
        }

        public override AquiculturaEnvelopeJSON Atualizar(AquiculturaPoco obj)
        {
            Aquicultura dom = this.mapeador.Mecanismo.Map<Aquicultura>(obj);
            Aquicultura atualizado = this.repositorio.Edit(dom);
            AquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<AquiculturaEnvelopeJSON>(atualizado);
            json.SetLinks();
            return json;
        }

        public override AquiculturaEnvelopeJSON Excluir(int id)
        {
            Aquicultura excluido = this.repositorio.DeleteById(id);
            AquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<AquiculturaEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }

        public override AquiculturaEnvelopeJSON Excluir(AquiculturaPoco obj)
        {
            return this.Excluir(obj.IdAquicultura);
        }
    }
}

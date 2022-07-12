using Atacado.EF.Database;
using Atacado.Poco.Auxiliar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Auxiliar
{
    public class RelatorioAquiculturaService
    {
        private AtacadoContext contexto;

        public RelatorioAquiculturaService()
        {
            this.contexto = new AtacadoContext();
        }

        public List<RelatorioAquiculturaPoco> RegistrosPorMunicipioAno(int id, int ano)
        {
            List<RelatorioAquiculturaPoco> lista =
                (from aqc in contexto.Aquiculturas
                 join mun in contexto.Municipios on aqc.IdMunicipio equals mun.IdMunicipio
                 join taqc in contexto.TipoAquiculturas on aqc.IdTipoAquicultura equals taqc.IdTipoAquicultura
                 join uf in contexto.UnidadeFederacaos on mun.SiglaUf equals uf.SiglaUf
                 where aqc.IdMunicipio == id && aqc.Producao != null && aqc.Ano == ano
                 select new RelatorioAquiculturaPoco()
                 {
                     IdAquicultura = aqc.IdAquicultura,
                     Ano = aqc.Ano,
                     IdMunicipio = aqc.IdMunicipio,
                     IdTipoAquicultura = aqc.IdTipoAquicultura,
                     Producao = aqc.Producao,
                     ValorProducao = aqc.ValorProducao,
                     ProporcaoValorProducao = aqc.ProporcaoValorProducao,
                     Moeda = aqc.Moeda,
                     NomeTipoAquicultura = taqc.DescricaoTipoAquicultura,
                     NomeMunicipio = mun.NomeMunicipio,
                     SiglaUf = mun.SiglaUf,
                     DescricaoUnidadeFederacao = uf.DescricaoUf
                 }).ToList();
            return lista;
        }

        public List<RelatorioAquiculturaPoco> RegistrosPorMunicipioTipoAquiculturaAno(int idMun, int idTipo, int ano)
        {
            List<RelatorioAquiculturaPoco> lista =
                (from aqc in contexto.Aquiculturas
                 join mun in contexto.Municipios on aqc.IdMunicipio equals mun.IdMunicipio
                 join taqc in contexto.TipoAquiculturas on aqc.IdTipoAquicultura equals taqc.IdTipoAquicultura
                 join uf in contexto.UnidadeFederacaos on mun.SiglaUf equals uf.SiglaUf
                 where aqc.IdMunicipio == idMun && aqc.IdTipoAquicultura == idTipo && aqc.Ano == ano
                 select new RelatorioAquiculturaPoco()
                 {
                     IdAquicultura = aqc.IdAquicultura,
                     Ano = aqc.Ano,
                     IdMunicipio = aqc.IdMunicipio,
                     IdTipoAquicultura = aqc.IdTipoAquicultura,
                     Producao = aqc.Producao,
                     ValorProducao = aqc.ValorProducao,
                     ProporcaoValorProducao = aqc.ProporcaoValorProducao,
                     Moeda = aqc.Moeda,
                     NomeTipoAquicultura = taqc.DescricaoTipoAquicultura,
                     NomeMunicipio = mun.NomeMunicipio,
                     SiglaUf = mun.SiglaUf,
                     DescricaoUnidadeFederacao = uf.DescricaoUf
                 }).ToList();
            return lista;
        }
    }
}

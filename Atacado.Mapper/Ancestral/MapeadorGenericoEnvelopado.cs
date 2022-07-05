using AutoMapper;

namespace Atacado.Mapper.Ancestral
{
    public class MapeadorGenericoEnvelopado<TPoco, TDom, TEnvelope> 
        where TPoco : class 
        where TDom : class 
        where TEnvelope : class
    {
        private IMapper mecanismo;

        public IMapper Mecanismo
        {
            get
            {
                if(this.mecanismo == null)
                {
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<TDom, TPoco>();
                        cfg.CreateMap<TDom, TEnvelope>();

                        cfg.CreateMap<TPoco, TDom>();
                        cfg.CreateMap<TPoco, TEnvelope>();

                        cfg.CreateMap<TEnvelope, TPoco>();
                        cfg.CreateMap<TEnvelope, TDom>();
                    });
                    this.mecanismo = configuration.CreateMapper();
                }
                return this.mecanismo;
            }
        }

        public MapeadorGenericoEnvelopado()
        { }
    }
}

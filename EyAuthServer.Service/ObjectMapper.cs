using AutoMapper;

namespace EyAuthServer.Service
{
    public static class ObjectMapper
    {
        //data memory istenildiğinde yüklenir çağırmazsan yüklenmez
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}

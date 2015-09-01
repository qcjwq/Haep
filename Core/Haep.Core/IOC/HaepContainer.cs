using Autofac;
using Autofac.Configuration;

namespace Haep.Core.IOC
{
    public static class HaepContainer
    {
        public static TService Get<TService>() where TService : class
        {
            var container = Builder.Build();
            return container.Resolve<TService>();
        }

        private static ContainerBuilder Builder
        {
            get
            {
                var builder = new ContainerBuilder();
                builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
                return builder;
            }
        }
    }
}
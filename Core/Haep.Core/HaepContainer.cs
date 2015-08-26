using Autofac;
using Autofac.Configuration;

namespace Haep.Core
{
    public static class HaepContainer
    {
        public static T Get<T>() where T : class
        {
            var container = Builder.Build();
            return container.Resolve<T>();
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
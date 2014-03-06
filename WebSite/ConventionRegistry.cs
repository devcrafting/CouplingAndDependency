namespace WebSite
{
    using System;
    using System.Linq;

    using UnityConfiguration;

    using WebSite.Models;

    public class ConventionRegistry : UnityRegistry
    {
        public ConventionRegistry()
        {
            this.Scan(
                x =>
                {
                    x.AssembliesInBaseDirectory(y => y.FullName.Contains("WebSite"));
                    x.WithFirstInterfaceConvention();
                    x.WithAddAllConvention().TypesImplementing(typeof(ICategoryRegisteredHandler)).AsSingleton();
                    x.With<Convention>();
                });
        }
    }

    public class Convention : IAssemblyScannerConvention
    {
        public void Process(Type type, IUnityRegistry registry)
        {
            var firstInterface = type.GetInterfaces().FirstOrDefault();
            if (firstInterface != null)
            {
                registry.Register(firstInterface, type);
            }
        }
    }
}
namespace WebSite
{
    using UnityConfiguration;

    using WebSite.Models;

    internal class ConventionRegistry : UnityRegistry
    {
        public ConventionRegistry()
        {
            this.Scan(x =>
                { 
                    x.AssembliesInBaseDirectory(assembly => assembly.FullName.StartsWith("WebSite"));
                    x.InternalTypes();
                    x.WithFirstInterfaceConvention();
                    x.WithAddAllConvention().TypesImplementing<ICategoryRegisteredHandler>().AsSingleton();
                });
        }
    }
}
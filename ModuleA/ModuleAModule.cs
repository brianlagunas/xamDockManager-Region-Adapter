using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA
{
    public class ModuleAModule
    {
        IUnityContainer _container;
        IRegionManager _manager;

        public ModuleAModule(IUnityContainer container, IRegionManager manager)
        {
            _container = container;
            _manager = manager;
        }

        public void Initialize()
        {

        }
    }
}

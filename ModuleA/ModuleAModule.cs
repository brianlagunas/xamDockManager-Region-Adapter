using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }
    }
}

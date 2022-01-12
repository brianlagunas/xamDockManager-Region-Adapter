using Infragistics.Windows.DockManager;
using Infrastructure.Prism;
using ModuleA;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Windows;
using XamDockManagerPrismRegionAdapter.Views;

namespace XamDockManagerPrismRegionAdapter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleAModule>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            regionAdapterMappings.RegisterMapping(typeof(TabGroupPane), Container.Resolve<TabGroupPaneRegionAdapter>());
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}

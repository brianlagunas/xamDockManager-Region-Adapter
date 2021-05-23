using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using System.Windows;
using Infragistics.Windows.DockManager;
using Infrastructure.Prism;
using Prism.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Ioc;

namespace XamDockManagerPrismRegionAdapter
{
    public class Bootstrapper : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>() ;
        }

        protected void InitializeShell()
        {
            InitializeShell();

            //App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            Prism.Modularity.ModuleCatalog catalog = new Prism.Modularity.ModuleCatalog();
            catalog.AddModule(typeof(ModuleA.ModuleAModule));
            return catalog;
        }

        protected RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(TabGroupPane), Container.Resolve<TabGroupPaneRegionAdapter>());
            return mappings;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}

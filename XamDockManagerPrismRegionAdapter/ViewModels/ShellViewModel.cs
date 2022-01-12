using Infrastructure;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using XamDockManagerPrismRegionAdapter.Business;

namespace XamDockManagerPrismRegionAdapter.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        IRegionManager _regionManager;

        public Random _randomNumberGenerator = new Random();
        int _randomMaxValue = 289876756;

        public ObservableCollection<DockView> Views { get; set; }

        public DelegateCommand<DockView> OpenCommand { get; set; }
        public DelegateCommand<DockView> CloseCommand { get; set; }

        public ShellViewModel(IRegionManager regionManager)
        {
            //_container = container;
            _regionManager = regionManager;

            OpenCommand = new DelegateCommand<DockView>(Open);
            CloseCommand = new DelegateCommand<DockView>(Close);

            //generate some data
            Views = new ObservableCollection<DockView>();
            Views.Add(new DockView() { Id = _randomNumberGenerator.Next(_randomMaxValue) });
            Views.Add(new DockView() { Id = _randomNumberGenerator.Next(_randomMaxValue) });
            Views.Add(new DockView() { Id = _randomNumberGenerator.Next(_randomMaxValue) });
            Views.Add(new DockView() { Id = _randomNumberGenerator.Next(_randomMaxValue) });
            Views.Add(new DockView() { Id = _randomNumberGenerator.Next(_randomMaxValue) });
        }

        void Close(DockView dockView)
        {
            if (dockView == null)
                return;

            IRegion region = _regionManager.Regions[KnownRegionNames.TabGroupPaneOne]; //get the region

            var view = region.Views.FirstOrDefault(v => (v as IDockView).Id == dockView.Id);
            if (view != null)
                region.Remove(view); //remove the viewModel
        }

        void Open(DockView dockView)
        {
            _regionManager.RequestNavigate(KnownRegionNames.TabGroupPaneOne, $"ViewA?id={dockView.Id}");
        }
    }
}

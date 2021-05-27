using Infrastructure;
using Prism.Commands;
using Prism.Regions;
using ModuleA;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Unity;

namespace XamDockManagerPrismRegionAdapter
{
    public class ShellViewModel : INotifyPropertyChanged
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        private ObservableCollection<ViewAViewModel> _views;
        public ObservableCollection<ViewAViewModel> Views
        {
            get { return _views; }
            set
            {
                _views = value;
                NotifyPropertyChanged("Views");
            }
        }

        public DelegateCommand<object> ActivateCommand { get; set; }
        public DelegateCommand<object> OpenCommand { get; set; }
        public DelegateCommand<object> CloseCommand { get; set; }

        public ShellViewModel(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;

            ActivateCommand = new DelegateCommand<object>(Activate);
            OpenCommand = new DelegateCommand<object>(Open, CanOpen);
            CloseCommand = new DelegateCommand<object>(Close);

            //generate some data
            Views = new ObservableCollection<ViewAViewModel>();
            Views.Add(_container.Resolve<ViewAViewModel>());
            Views.Add(_container.Resolve<ViewAViewModel>());
            Views.Add(_container.Resolve<ViewAViewModel>());
            Views.Add(_container.Resolve<ViewAViewModel>());
            Views.Add(_container.Resolve<ViewAViewModel>());
            Views.Add(_container.Resolve<ViewAViewModel>());
            Views.Add(_container.Resolve<ViewAViewModel>());
            Views.Add(_container.Resolve<ViewAViewModel>());
            Views.Add(_container.Resolve<ViewAViewModel>());
        }

        void Activate(object viewModel)
        {
            if (viewModel == null)
                return;

            IRegion region = _regionManager.Regions[KnownRegionNames.TabGroupPaneOne]; //get the region
            if (region.Views.Contains(viewModel))
                region.Activate(viewModel); //activate the viewModel
        }

        void Close(object viewModel)
        {
            if (viewModel == null)
                return;

            IRegion region = _regionManager.Regions[KnownRegionNames.TabGroupPaneOne]; //get the region
            if (region.Views.Contains(viewModel))
                region.Remove(viewModel); //remove the viewModel
        }

        void Open(object viewModel)
        {
            IRegion region = _regionManager.Regions[KnownRegionNames.TabGroupPaneOne]; //get the region

            if (!region.Views.Contains(viewModel))
                region.Add(viewModel); //add the viewModel

            region.Activate(viewModel); //active the viewModel
        }

        bool CanOpen(object viewModel)
        {
            return viewModel != null;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion //INotifyPropertyChanged
    }
}

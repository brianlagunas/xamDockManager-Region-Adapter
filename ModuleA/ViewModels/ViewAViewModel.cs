using System;
using Infrastructure;
using Prism;
using Prism.Mvvm;
using Prism.Regions;
using XamDockManagerPrismRegionAdapter.Business;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase, IDockView, IActiveAware, IDockAware, INavigationAware
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                Header = String.Format("Title: {0}", value);
                SetProperty(ref _id, value);
            }
        }

        #region IActiveAware

        bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value); }
        }

        public event EventHandler IsActiveChanged;

        #endregion //IActiveAware

        #region IDockAware

        private string _header;
        public string Header
        {
            get { return _header; }
            set { SetProperty(ref _header, value); }
        }

        #endregion //IDockAware

        #region INavigationAware

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Id = navigationContext.Parameters.GetValue<int>("id");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return navigationContext.Parameters.GetValue<int>("id") == Id;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        #endregion //INavigationAware
    }
}

using System;
using System.ComponentModel;
using Infrastructure.Prism;
using Prism;

namespace ModuleA
{
    public class ViewAViewModel : INotifyPropertyChanged, IActiveAware, IDockAware
    {
        public static Random _randomNumberGenerator = new Random();
        int _randomMaxValue = 289876756;

        public ViewAViewModel()
        {
            Number = _randomNumberGenerator.Next(_randomMaxValue);
        }

        private int _number;
        public int Number 
        {
            get { return _number; }
            set
            {
                _number = value;
                Header = String.Format("Title: {0}", _number);
                NotifyPropertyChanged("Number");
            }
        }

        #region IActiveAware

        bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                NotifyPropertyChanged("IsActive");
            }
        }

        public event EventHandler IsActiveChanged;

        #endregion //IActiveAware

        #region IDockAware

        private string _header;
        public string Header
        {
            get { return _header; }
            set
            {
                _header = value;
                NotifyPropertyChanged("Header");
            }
        }

        #endregion //IDockAware

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

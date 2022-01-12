using System.Windows.Controls;
using XamDockManagerPrismRegionAdapter.Business;

namespace ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class ViewA : UserControl, IDockView
    {
        public int Id
        {
            get { return ((IDockView)DataContext).Id; }
        }

        public ViewA()
        {
            InitializeComponent();
        }
    }
}

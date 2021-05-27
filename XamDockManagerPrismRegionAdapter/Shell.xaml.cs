using System.Windows;

namespace XamDockManagerPrismRegionAdapter
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell(ShellViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void XamDockManager_ToolWindowLoaded(object sender, Infragistics.Windows.DockManager.Events.PaneToolWindowEventArgs e)
        {
            e.Window.UseOSNonClientArea = false;
        }
    }
}

namespace XamDockManagerPrismRegionAdapter.Business
{
    public interface IDockView
    {
        int Id { get; }
    }

    public class DockView : IDockView
    {
        public int Id { get; set; }
    }
}

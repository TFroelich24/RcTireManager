namespace RcTireManager.Interfaces.Viewmodels
{
    public interface IViewModelConfiguration :IViewModelTireManager
    {
        void Update();
        void Remove();
        void Add();
    }
}

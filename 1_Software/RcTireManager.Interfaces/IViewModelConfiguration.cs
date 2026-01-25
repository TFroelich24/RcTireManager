using RcTireManager.Data.DTO;

namespace RcTireManager.Interfaces.Viewmodels
{
    public interface IViewModelConfiguration :IViewModelTireManager
    {
        string SelectedConfiguration { get; set; }
        void Update();
        void Remove();
        void Add();
    }
}

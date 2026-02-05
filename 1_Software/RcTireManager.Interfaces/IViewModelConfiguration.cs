using RcTireManager.Data.DTO;
using System.Collections.ObjectModel;

namespace RcTireManager.Interfaces.Viewmodels
{
    public interface IViewModelConfiguration :IViewModelTireManager
    {
        string SelectedConfiguration { get; set; }
        ObservableCollection<BaseItemDTO> ItemsList { get; set; }
        void Update(BaseItemDTO item);
        void Remove(BaseItemDTO item);
        void Add();
    }
}

using RcTireManager.Data.DTO;
using RcTireManager.Interfaces.Viewmodels;
using System.Collections.ObjectModel;

namespace RcTireManager.Interfaces
{
    public interface IViewModelTireManager : IViewModelBase
    {
        public ObservableCollection<CarDTO> Cars { get; set; }
        public CarDTO? SelectedCar { get; set; }
        public TireSetDTO? SelectedTireSet { get; set; }
        public ObservableCollection<TireSetDTO> TireSets { get; set; }
    }
}

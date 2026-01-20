using RcTireManager.Data.DTO;
using RcTireManager.Interfaces.Logic;
using System.Collections.ObjectModel;

namespace RcTireManager.Interfaces.Viewmodels
{
    public interface IViewModelHome : IViewModelBase
    {
        public ObservableCollection<CarDTO> Cars { get; set; }
        public CarDTO? SelectedCar { get; set; }
        public TireSetDTO? SelectedTireSet { get; set; }
        public ObservableCollection<TireSetDTO> TireSets { get; set; }
        public TimeSpan? RunTime { get; set; }

    }
}
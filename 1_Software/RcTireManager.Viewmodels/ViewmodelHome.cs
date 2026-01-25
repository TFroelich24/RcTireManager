using Microsoft.AspNetCore.Mvc.RazorPages;
using RcTireManager.Data.DTO;
using RcTireManager.Interfaces.Logic;
using RcTireManager.Interfaces.Viewmodels;
using System.Collections.ObjectModel;

namespace RcTireManager.Viewmodels
{
    public class ViewModelHome : PageModel, IViewModelHome
    {
        ILogicHome? _logic;
        public ObservableCollection<CarDTO> Cars { get; set; }
        public CarDTO? SelectedCar { get; set; }
        public TireSetDTO? SelectedTireSet { get; set; }
        public ObservableCollection<TireSetDTO> TireSets { get; set; }
        public TimeSpan? RunTime { get; set; }


        public ViewModelHome()
        {
            Cars = new();
            TireSets = new();
            SelectedCar = new CarDTO();
            SelectedTireSet = new TireSetDTO();
            TireSets = new ObservableCollection<TireSetDTO>();            
        }
         
        public void SetReferenceToBusinessLogic(ILogicBase logic)
        {
            _logic = (ILogicHome)logic;
        }

        public void SaveRun()
        {
            if (_logic != null)
                _logic.SaveRun();            
        }
    }
}

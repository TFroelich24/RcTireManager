using Microsoft.AspNetCore.Mvc.RazorPages;
using RcTireManager.Data.DTO;
using RcTireManager.Interfaces;
using RcTireManager.Interfaces.Logic;
using RcTireManager.Interfaces.Viewmodels;
using System.Collections.ObjectModel;

namespace RcTireManager.Viewmodels
{
    public class ViewModelConfiguration : PageModel, IViewModelConfiguration
    {
        ILogicConfiguration? _logic;
        public CarDTO? SelectedCar { get; set; }
        public TireSetDTO? SelectedTireSet { get; set; }
        public ObservableCollection<CarDTO> Cars { get; set; }
        public ObservableCollection<TireSetDTO> TireSets { get; set; }
        public ObservableCollection<BaseItemDTO> ItemsList { get; set; }

        private string selectedConfiguration;
        public string SelectedConfiguration
        {
            get
            {
                return selectedConfiguration;
            }
            set
            {
                if (selectedConfiguration != value)
                {
                    selectedConfiguration = value;
                    _logic?.SetItemsList(selectedConfiguration);                    
                }
            }
        }
        
        public ViewModelConfiguration()
        {
            SelectedConfiguration = string.Empty;
            Cars = new();
            TireSets = new();
            SelectedCar = new();
            SelectedTireSet = new();
        }
        public void SetReferenceToBusinessLogic(ILogicBase logic)
        {
            _logic = (ILogicConfiguration)logic;
        }
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

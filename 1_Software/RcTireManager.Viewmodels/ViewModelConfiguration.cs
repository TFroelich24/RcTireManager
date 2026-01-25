using Microsoft.AspNetCore.Mvc.RazorPages;
using RcTireManager.Data.DTO;
using RcTireManager.Interfaces;
using RcTireManager.Interfaces.Logic;
using RcTireManager.Interfaces.Viewmodels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcTireManager.Viewmodels
{
    public class ViewModelConfiguration : PageModel, IViewModelConfiguration
    {
        ILogicConfiguration? _logic;
        public ObservableCollection<CarDTO> Cars { get; set; }
        public CarDTO? SelectedCar { get; set; }
        public TireSetDTO? SelectedTireSet { get; set; }
        public ObservableCollection<TireSetDTO> TireSets { get; set; }
        public string SelectedConfiguration { get; set; }

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

using RcTireManager.Data;
using RcTireManager.Data.DTO;
using RcTireManager.Interfaces;
using RcTireManager.Interfaces.Viewmodels;
using System.Collections.ObjectModel;

namespace RcTireManager.Logic
{
    public class LogicConfiguration : ILogicConfiguration
    {
        private DataContext _dataContext;
        private IViewModelConfiguration _viewmodel;

        public LogicConfiguration(IViewModelConfiguration viewmodel)
        {
            _dataContext = new DataContext();
            _viewmodel = viewmodel;
            loadAllDataFromDataContext();
        }

        private void loadAllDataFromDataContext()
        {
            if (_dataContext?.Cars != null)
                _viewmodel.Cars = _dataContext.Cars;
            if (_dataContext?.TireSets != null)
                _viewmodel.TireSets = _dataContext.TireSets;

            setDefaultValuesIfDataIsNotEmpty();
        }

        private void setDefaultValuesIfDataIsNotEmpty()
        {
            _viewmodel.SelectedTireSet = null;
            _viewmodel.SelectedCar = null;
        }
        public void Add(string selectedConfiguration)
        {
            if (_dataContext != null)
            {
                switch (selectedConfiguration)
                {
                    case nameof(_viewmodel.SelectedCar):
                        CarDTO newCar = new CarDTO() { Name = "New Car", IsActive = true, ID = _dataContext.Cars.Last().ID + 1 };
                        ObservableCollection<CarDTO>? cars = _dataContext.Cars;
                        cars.Add(newCar);
                        _dataContext.Cars = cars;
                        break;

                    case nameof(_viewmodel.SelectedTireSet):
                        TireSetDTO newTireSet = new TireSetDTO() { Name = "New Tire Set", IsActive = true, ID = _dataContext.TireSets.Last().ID + 1 };
                        ObservableCollection<TireSetDTO>? tireSets = _dataContext.TireSets;
                        tireSets.Add(newTireSet);
                        _dataContext.TireSets = tireSets;
                        break;

                }
            }
        }

        public void SetInactive(BaseItemDTO item)
        {
            if (_dataContext != null)
            {
                if (item.GetType() == typeof(CarDTO))
                {
                    ObservableCollection<CarDTO> cars = _dataContext.Cars;
                    cars.Where(car => car.ID == item.ID).FirstOrDefault().IsActive = false;
                    _dataContext.Cars = cars;
                }
                else if (item.GetType() == typeof(TireSetDTO))
                {
                    ObservableCollection<TireSetDTO> tireSets = _dataContext.TireSets;
                    tireSets.Where(tireSet => tireSet.ID == item.ID).FirstOrDefault().IsActive = false;
                    _dataContext.TireSets = tireSets;
                }
            }
        }

        public void SetActive(BaseItemDTO item)
        {
            if (_dataContext != null)
            {
                if (item.GetType() == typeof(CarDTO))
                {
                    ObservableCollection<CarDTO> cars = _dataContext.Cars;
                    cars.Where(car => car.ID == item.ID).FirstOrDefault().IsActive = true;
                    _dataContext.Cars = cars;
                }
                else if (item.GetType() == typeof(TireSetDTO))
                {
                    ObservableCollection<TireSetDTO> tireSets = _dataContext.TireSets;
                    tireSets.Where(tireSet => tireSet.ID == item.ID).FirstOrDefault().IsActive = true;
                    _dataContext.TireSets = tireSets;
                }
            }
        }

        public void SetItemsList(string selectedConfiguration)
        {
            _viewmodel.ItemsList = new();
            if (_dataContext != null && _dataContext?.TireSets != null && _dataContext.Cars != null)
            {
                switch (selectedConfiguration)
                {
                    case nameof(_viewmodel.SelectedCar):
                        foreach (CarDTO car in _dataContext.Cars.OrderByDescending(c => c.IsActive))
                            _viewmodel.ItemsList.Add(car);
    
                        break;

                    case nameof(_viewmodel.SelectedTireSet):
                        foreach (TireSetDTO tireSet in _dataContext.TireSets.OrderByDescending(t => t.IsActive))
                            _viewmodel.ItemsList.Add(tireSet);

                        break;
                    default:
                        break;
                }
            }
        }

        public void Update(BaseItemDTO item)
        {
            if (_dataContext != null)
            {
                if (item.GetType() == typeof(CarDTO) && item is CarDTO carToUpdate)
                {
                    ObservableCollection<CarDTO> cars = _dataContext.Cars;
                    var existingCar = cars.Where(car => car.ID == item.ID).FirstOrDefault();
                    if (existingCar != null)
                    {
                        int index = cars.IndexOf(existingCar);
                        cars[index] = carToUpdate;
                        _dataContext.Cars = cars;
                    }
                }
                else if (item.GetType() == typeof(TireSetDTO) && item is TireSetDTO tireSetToUpdate)
                {
                    ObservableCollection<TireSetDTO> tireSets = _dataContext.TireSets;
                    var existingTireSet = tireSets.Where(tireSet => tireSet.ID == item.ID).FirstOrDefault();
                    if (existingTireSet != null)
                    {
                        int index = tireSets.IndexOf(existingTireSet);
                        tireSets[index] = tireSetToUpdate;
                        _dataContext.TireSets = tireSets;
                    }
                }
            }
        }
    }
}

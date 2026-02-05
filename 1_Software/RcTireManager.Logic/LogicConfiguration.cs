using RcTireManager.Data;
using RcTireManager.Data.DTO;
using RcTireManager.Interfaces;
using RcTireManager.Interfaces.Viewmodels;

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
        public void Add(BaseItemDTO item)
        {
            throw new NotImplementedException();
        }

        public void Remove(BaseItemDTO item)
        {
            BaseItemDTO? removeMe = _dataContext?.Cars?.Where(c => c.ID == item.ID).FirstOrDefault();
            _dataContext?.Cars?.RemoveAt(removeMe.ID);
        }

      

        public void SetItemsList(string selectedConfiguration)
        {
            _viewmodel.ItemsList = new();
            if (_dataContext != null && _dataContext?.TireSets != null && _dataContext.Cars != null)
            {
                switch (selectedConfiguration)
                {
                    case nameof(_viewmodel.SelectedCar):
                        foreach (CarDTO car in _dataContext.Cars)
                            _viewmodel.ItemsList.Add(car);

                        break;

                    case nameof(_viewmodel.SelectedTireSet):
                        foreach (TireSetDTO tireSet in _dataContext.TireSets)
                            _viewmodel.ItemsList.Add(tireSet);

                        break;
                    default:
                        break;
                }
            }
        }

        public void Update(BaseItemDTO item)
        {
            throw new NotImplementedException();
        }
    }
}

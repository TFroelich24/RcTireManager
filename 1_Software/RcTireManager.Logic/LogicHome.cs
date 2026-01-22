using RcTireManager.Data;
using RcTireManager.Data.DTO;
using RcTireManager.Interfaces.Viewmodels;
using System.Collections.ObjectModel;

namespace RcTireManager.Interfaces.Logic
{
    public class LogicHome : ILogicHome
    {
        DataContext _dataContext;
        IViewModelHome _viewmodel;
        public LogicHome(IViewModelHome viewmodel)
        {
            _dataContext = new DataContext();
            _viewmodel = viewmodel;
            loadAllDataFromDataContext();
        }

        public void AddCar()
        {
            throw new NotImplementedException();
        }

        public void AddTireSet()
        {
            throw new NotImplementedException();
        }

        public void DeleteCar()
        {
            throw new NotImplementedException();
        }

        public void DeleteTireSet()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            loadAllDataFromDataContext();
        }

        public void RefreshData()
        {
            loadAllDataFromDataContext();
        }

        private void loadAllDataFromDataContext()
        {
            if (_dataContext.Cars != null)
                _viewmodel.Cars = _dataContext.Cars;
            if (_dataContext.TireSets != null)
                _viewmodel.TireSets = _dataContext.TireSets;

            setDefaultValuesIfDataIsNotEmpty();
        }

        private void setDefaultValuesIfDataIsNotEmpty()
        {
            _viewmodel.SelectedTireSet = null;
            _viewmodel.SelectedCar = null;
        }
        public void SaveRun()
        {
            if (_viewmodel.SelectedTireSet != null && _viewmodel.RunTime != null && _viewmodel.SelectedCar != null && _dataContext != null)
            {
                _viewmodel.SelectedTireSet.RunTime += (TimeSpan)_viewmodel.RunTime;
                TireSetDTO? tire = _dataContext.TireSets?.Where(t => t.ID == _viewmodel.SelectedTireSet.ID).First();
                ObservableCollection<TireSetDTO>? sets = new();
                sets = _dataContext.TireSets;
                
                if (tire != null)
                    sets?.Remove(tire);
                sets?.Add(_viewmodel.SelectedTireSet);
                _dataContext.TireSets = sets;
            }
            else
            {
                //TODO show ärror
            }
        }
    }
}

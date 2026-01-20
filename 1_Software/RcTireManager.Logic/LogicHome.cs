using RcTireManager.Data;
using RcTireManager.Interfaces.Viewmodels;

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
            _viewmodel.SelectedTireSet = _dataContext.TireSets?.FirstOrDefault();
            _viewmodel.SelectedCar = _dataContext.Cars?.FirstOrDefault();
        }

        public void SaveRun()
        {
            throw new NotImplementedException();
        }
    }
}

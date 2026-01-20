
namespace RcTireManager.Interfaces.Logic
{
    public interface ILogicHome : ILogicBase
    {
        void RefreshData();
        void SaveRun();
        void AddTireSet();
        void DeleteTireSet();
        void AddCar();
        void DeleteCar();
    }
}
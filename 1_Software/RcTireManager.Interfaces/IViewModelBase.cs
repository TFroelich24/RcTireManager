using RcTireManager.Interfaces.Logic;

namespace RcTireManager.Interfaces.Viewmodels
{
    public interface IViewModelBase
    {
        void SetReferenceToBusinessLogic(ILogicBase logic);        
    }
}
using RcTireManager.Data.DTO;
using RcTireManager.Interfaces.Logic;
using System.Collections.ObjectModel;

namespace RcTireManager.Interfaces.Viewmodels
{
    public interface IViewModelHome : IViewModelTireManager
    {
        public TimeSpan? RunTime { get; set; }
        void SaveRun();
    }
}
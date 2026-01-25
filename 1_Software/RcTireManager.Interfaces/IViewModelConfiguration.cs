using RcTireManager.Interfaces.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcTireManager.Interfaces
{
    public interface IViewModelConfiguration :IViewModelTireManager
    {
        void Update();
        void Remove();
        void Add();
    }
}

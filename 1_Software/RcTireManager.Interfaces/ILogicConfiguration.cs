using RcTireManager.Data.DTO;
using RcTireManager.Interfaces.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcTireManager.Interfaces
{
    public interface ILogicConfiguration :ILogicBase
    {
        void Add(BaseDTO item);
        void Update(BaseDTO item);
        void Remove(BaseDTO item);
    }
}

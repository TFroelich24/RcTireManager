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
        void Add(string selectedConfiguration);
        void Update(BaseItemDTO item);
        void SetInactive(BaseItemDTO item);
        void SetActive(BaseItemDTO item);
        void SetItemsList(string selectedConfiguration);
    }
}

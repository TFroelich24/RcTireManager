using RcTireManager.Data.DTO;
using RcTireManager.Interfaces.Viewmodels;

namespace RcTireManager.Viewmodels
{
    public class ViewModelEditItemDialog : IViewModelEditItemDialog
    {      
        public BaseItemDTO? Item { get; set; }       
    }
}

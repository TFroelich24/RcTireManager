using RcTireManager.Data.DTO;

namespace RcTireManager.Interfaces.Viewmodels
{
    public interface IViewModelEditItemDialog
    {
        BaseItemDTO? Item { get; set; }
        bool HasChanges { get; }
        bool ValidateItem();
    }
}

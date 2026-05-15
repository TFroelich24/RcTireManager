using RcTireManager.Data.DTO;
using RcTireManager.Interfaces.Viewmodels;

namespace RcTireManager.Viewmodels
{
    public class ViewModelEditItemDialog : IViewModelEditItemDialog
    {
        private BaseItemDTO? _originalItem;

        public BaseItemDTO? Item { get; set; }

        public bool HasChanges
        {
            get
            {
                if (Item == null || _originalItem == null)
                    return false;

                if (Item.Name != _originalItem.Name)
                    return true;

                if (Item is TireSetDTO tireSet && _originalItem is TireSetDTO originalTireSet)
                {
                    return tireSet.Type != originalTireSet.Type ||
                           tireSet.Compound != originalTireSet.Compound;
                }

                if (Item is CarDTO car && _originalItem is CarDTO originalCar)
                {
                    return car.CarType != originalCar.CarType;
                }

                return false;
            }
        }

        public bool ValidateItem()
        {
            if (Item == null)
                return false;

            if (string.IsNullOrWhiteSpace(Item.Name))
                return false;

            return true;
        }

        private void SaveOriginalItem()
        {
            _originalItem = CloneItem(Item);
        }

        private BaseItemDTO? CloneItem(BaseItemDTO? item)
        {
            if (item == null)
                return null;

            if (item is TireSetDTO tireSet)
            {
                return new TireSetDTO
                {
                    ID = tireSet.ID,
                    Name = tireSet.Name,
                    RunTime = tireSet.RunTime,
                    MaxRuntime = tireSet.MaxRuntime,
                    IsActive = tireSet.IsActive,
                    Type = tireSet.Type,
                    Compound = tireSet.Compound
                };
            }
            else if (item is CarDTO car)
            {
                return new CarDTO
                {
                    ID = car.ID,
                    Name = car.Name,
                    RunTime = car.RunTime,
                    MaxRuntime = car.MaxRuntime,
                    IsActive = car.IsActive,
                    CarType = car.CarType
                };
            }

            return null;
        }
    }
}

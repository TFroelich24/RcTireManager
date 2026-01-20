using System.Collections.ObjectModel;

namespace RcTireManager.Data.Interfaces
{
    public interface IDataTable<Type>
    {
        ObservableCollection<Type> GetAll();
        Type GetById();
    }
}

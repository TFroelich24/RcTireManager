
using RcTireManager.Data.DTO;
using System.Collections.ObjectModel;

namespace RcTireManager.Data.Interfaces
{
    public interface IBaseTable<T> where T : BaseDTO
    {
        ObservableCollection<T> GetAll();
        void UpdateTable(ObservableCollection<T>? data);
        void Add(T item);
        void AddIfNotExistsOrUpdate(T item);
    }
}
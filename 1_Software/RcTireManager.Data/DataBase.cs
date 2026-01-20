using RcTireManager.Data.DTO;
using System.Collections.ObjectModel;
using System.Reflection;

namespace RcTireManager.Data
{
    public abstract class DataBase
    {
        private readonly Dictionary<Type, object> _tables = new();
        protected BaseTable<T> GetTable<T>(string name)
        {
            if (!_tables.TryGetValue(typeof(T), out var table))
            {
                table = new BaseTable<T>(name);
                _tables[typeof(T)] = table;
            }
            return (BaseTable<T>)table!;
        }
    }
}
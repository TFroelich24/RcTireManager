using RcTireManager.Data.Interfaces;
using System.Runtime.CompilerServices;

namespace RcTireManager.Data
{
    public class DataBase
    {
        private readonly Dictionary<string, object> _tables = new();
        public IBaseTable<T> GetTable<T>([CallerMemberName] string memberName = "")
        {
            var key = memberName ?? typeof(T).Name;

            if (_tables.TryGetValue(key, out var existing) && existing is IBaseTable<T> table)
                return table;

            var newTable = new BaseTable<T>(key);
            _tables[key] = newTable;
            return newTable;
        }
    }
}
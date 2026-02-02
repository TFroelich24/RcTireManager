using RcTireManager.Data.DTO;
using System.Collections.ObjectModel;

namespace RcTireManager.Data
{
    public class DataContext : DataBase
    {
        private readonly DataBase _database;

        public DataContext() : this(new DataBase()) { }

        public DataContext(DataBase database)
        {
            _database = database;
        }

        public ObservableCollection<CarDTO>? Cars
        {
            get => _database.GetTable<CarDTO>(nameof(Cars)).GetAll();
            set => _database.GetTable<CarDTO>(nameof(Cars)).UpdateTable(value);
        }

        public ObservableCollection<TireSetDTO>? TireSets
        {
            get => _database.GetTable<TireSetDTO>(nameof(TireSets)).GetAll();
            set => _database.GetTable<TireSetDTO>(nameof(TireSets)).UpdateTable(value);
        }
    }
}

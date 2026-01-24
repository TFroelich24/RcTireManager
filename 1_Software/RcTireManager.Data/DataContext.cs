using RcTireManager.Data.DTO;
using RcTireManager.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcTireManager.Data
{
    public class DataContext
    {
        public DataContext()
        {
            tireSets = new ObservableCollection<TireSetDTO>();
            cars = new ObservableCollection<CarDTO>();

            //if (Cars== null || TireSets == null /*|| Cars.Count == 0 && TireSets.Count == 0*/)
            //{
            //    TireSetDTO tireSet0 = new() { ID = 0, Name = "Swaggers", RunTime = new TimeSpan(0, 3, 0), Compound = "Pink", Type = "Indoor" };
            //    TireSetDTO tireSet1 = new() { ID = 0, Name = "Cactus", RunTime = new TimeSpan(0, 0, 0), Compound = "Yellow", Type = "Indoor" };
            //    TireSetDTO tireSet2 = new() { ID = 1, Name = "Cactus", RunTime = new TimeSpan(0, 5, 0), Compound = "Yellow", Type = "Indoor" };
            //    TireSetDTO tireSet3 = new() { ID = 0, Name = "FuzzBite", RunTime = new TimeSpan(0, 3, 0), Compound = "Pink", Type = "Indoor" };
            //    CarDTO buggy = new() {ID = 0, CarType = CarDTO.CarTypeEnum.Buggy_2WD, Name = "B6.4", TireSetsIDs = new ObservableCollection<int>() { tireSet1.ID, tireSet2.ID} };
            //    CarDTO truck = new() { ID = 0, CarType = CarDTO.CarTypeEnum.StadiumTruck, Name = "T6.2", TireSetsIDs = new ObservableCollection<int>() { tireSet3.ID, tireSet0.ID } };

            //    _tireSetsTable.Add(tireSet0);
            //    _tireSetsTable.Add(tireSet1);
            //    _tireSetsTable.Add(tireSet2);
            //    _tireSetsTable.Add(tireSet3);
            //    _carsTable.Add(buggy);
            //    _carsTable.Add(truck);
            //}

        }

        private BaseTable<CarDTO>? _carsTable = new("Car");
        private BaseTable<TireSetDTO>? _tireSetsTable = new("TireSet");

        private ObservableCollection<CarDTO>? cars;
        public ObservableCollection<CarDTO>? Cars
        {
            get
            {
                if (_carsTable != null)
                    return _carsTable.GetAll();
                else
                    return null;
            }

            set
            {
                if (cars != value)
                    _carsTable?.UpdateTable(value);

            }
        }

        private ObservableCollection<TireSetDTO>? tireSets;
        public ObservableCollection<TireSetDTO>? TireSets
        {
            get
            {
                if (_tireSetsTable != null)
                    return _tireSetsTable.GetAll();
                else
                    return null;
            }

            set
            {
                if (tireSets != value)
                    _tireSetsTable?.UpdateTable(value);

            }
        }
    }
}

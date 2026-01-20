using Microsoft.VisualBasic;
using RcTireManager.Data.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace RcTireManager.Data.DTO
{

    public class CarDTO : BaseDTO
    {
        public CarDTO()
        {
            name = string.Empty;
            tireSetsIDs = new ObservableCollection<int>();            
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private ObservableCollection<int> tireSetsIDs;

        public ObservableCollection<int> TireSetsIDs
        {
            get { return tireSetsIDs; }
            set { tireSetsIDs = value; }
        }

        private CarTypeEnum carType;

        public CarTypeEnum CarType
        {
            get { return carType; }
            set { carType = value; }
        }

        public enum CarTypeEnum
        {
            CarType_None,
            MonsterTruck,
            StadiumTruck,
            Touringcar,
            Buggy_2WD,
            Buggy_4WD,
            ShortCourse
        }     
    }
}


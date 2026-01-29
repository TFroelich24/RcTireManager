using Microsoft.VisualBasic;
using RcTireManager.Data.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace RcTireManager.Data.DTO
{

    public class CarDTO : BaseItemDTO
    {
        public CarDTO()
        {
            tireSetsIDs = new ObservableCollection<int>();            
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
            None,
            MonsterTruck,
            StadiumTruck,
            Touringcar,
            Buggy_2WD_Stock,
            Buggy_4WD_Stock,
            Buggy_2WD_Modified,
            Buggy_4WD_Modified,
            ShortCourse
        }

        public override string GetItemTypeName()
        {
            return carType.ToString().Replace("_"," ");
        }
    }
}


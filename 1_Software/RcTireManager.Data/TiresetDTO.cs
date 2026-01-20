using System;

namespace RcTireManager.Data.DTO
{


    public class TireSetDTO : BaseDTO
    {
        public TireSetDTO()
        {
            name = string.Empty;
            type = string.Empty;
            compound = string.Empty;
            runTime = new TimeSpan();
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }


        private string compound;
        public string Compound
        {
            get { return compound; }
            set { compound = value; }
        }


        private TimeSpan runTime;
        public TimeSpan RunTime
        {
            get { return runTime; }
            set { runTime = value; }
        }

    }
}
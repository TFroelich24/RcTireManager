using System;

namespace RcTireManager.Data.DTO
{


    public class TireSetDTO : BaseItemDTO
    {
        public TireSetDTO()
        {
            type = string.Empty;
            compound = string.Empty;
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
    }
}
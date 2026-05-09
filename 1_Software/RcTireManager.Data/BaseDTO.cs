namespace RcTireManager.Data.DTO
{
    public class BaseDTO
    {
        private int id;
        
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public bool IsActive { get; set; }
    }
}
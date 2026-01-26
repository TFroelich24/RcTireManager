namespace RcTireManager.Data.DTO
{
    public class BaseItemDTO : BaseDTO
    {
        public BaseItemDTO()
        {
            name = string.Empty;
        }

        private TimeSpan runTime;
        public TimeSpan RunTime
        {
            get { return runTime; }
            set { runTime = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}

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

        private TimeSpan _maxRunTime;

        public TimeSpan MaxRuntime
        {
            get { return _maxRunTime; }
            set { _maxRunTime = value; }
        }


        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string GetItemTypeName()
        {
            return string.Empty;
        }

        public double GetRuntimeInMinutes()
        {
            return runTime.TotalHours + runTime.Minutes;
        }
    }
}

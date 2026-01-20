using RcTireManager.Data.DTO;

namespace RcTireManager.Data
{
    public interface IDataContext
    {
        CarDTO Cars { get; set; }
        TireSetDTO TireSets { get; set; }
    }
}
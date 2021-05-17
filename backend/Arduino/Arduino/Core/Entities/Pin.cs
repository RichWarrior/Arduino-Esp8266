using Dapper.Contrib.Extensions;

namespace Core.Entities
{
    [Table("pin")]
    public class Pin :BaseEntity
    {
        public int DeviceTypeId { get; set; }
        public string PinName { get; set; }
        public bool IsDefault { get; set; }
    }
}

using Dapper.Contrib.Extensions;

namespace Core.Entities
{
    [Table("devicedetail")]
    public class DeviceDetail : BaseEntity
    {
        public int DeviceId { get; set; }
        public int SensorId { get; set; }
        public int PinId { get; set; }
        public string Description { get; set; }

        [Write(false)]
        public string SensorName { get; set; }
        
        [Write(false)]
        public string Pin { get; set; }

        [Write(false)]
        public bool IsPinDefault { get; set; }
    }
}

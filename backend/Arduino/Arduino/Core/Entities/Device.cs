using Dapper.Contrib.Extensions;

namespace Core.Entities
{
    [Table("device")]
    public class Device : BaseEntity
    {
        public int UserId { get; set; }
        public int DeviceTypeId { get; set; }
        public string DeviceKey { get; set; }
        public string Name { get; set; }
    }
}

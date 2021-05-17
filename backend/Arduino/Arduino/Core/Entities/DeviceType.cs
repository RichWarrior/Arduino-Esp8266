using Dapper.Contrib.Extensions;

namespace Core.Entities
{
    [Table("devicetype")]
    public class DeviceType : BaseEntity
    {
        public string Name { get; set; }
    }
}

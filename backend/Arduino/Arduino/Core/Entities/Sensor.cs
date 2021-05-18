using Dapper.Contrib.Extensions;

namespace Core.Entities
{
    [Table("sensor")]
    public class Sensor : BaseEntity
    {
        public string Name { get; set; }
    }
}

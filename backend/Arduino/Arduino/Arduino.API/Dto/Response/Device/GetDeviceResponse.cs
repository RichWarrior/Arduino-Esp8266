namespace Arduino.API.Dto.Response.Device
{
    /// <summary>
    /// 
    /// </summary>
    public class GetDeviceResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public DeviceItem Device { get; set; }


        public sealed class DeviceItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int DeviceTypeId { get; set; }
            public string DeviceTypeName { get; set; }
        }
    }
}

using System.Collections.Generic;

namespace Arduino.API.Dto.Response.Device
{
    public class ListDeviceResponse
    {
        public List<Device> Devices { get; set; }

        public ListDeviceResponse()
        {
            Devices = new List<Device>();
        }

        public sealed class Device
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string DeviceTypeName { get; set; }
        }
    }
}

using System.Collections.Generic;

namespace Arduino.API.Dto.Response.Device
{
    public class GetDeviceSensorsResponse
    {
        public List<DeviceSensor> DeviceSensors{ get; set; }

        public GetDeviceSensorsResponse()
        {
            DeviceSensors = new List<DeviceSensor>();
        }

        public sealed class DeviceSensor
        {
            /// <summary>
            /// 
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Pin { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string SensorName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Description { get; set; }
        }
    }
}

using System.Collections.Generic;

namespace Arduino.API.Dto.Response.Device
{
    public class GetSensorResponse
    {
        public List<Sensor> Sensors { get; set; }

        public GetSensorResponse()
        {
            Sensors = new List<Sensor>();
        }
        public sealed class Sensor
        {
            /// <summary>
            /// 
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Name { get; set; }
        }
    }
}

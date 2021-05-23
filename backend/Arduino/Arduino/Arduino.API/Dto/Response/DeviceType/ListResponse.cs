using System.Collections.Generic;

namespace Arduino.API.Dto.Response.DeviceType
{
    public class ListResponse
    {

        public List<DeviceType> DeviceTypes { get; set; }

        public ListResponse()
        {
            DeviceTypes = new List<DeviceType>();
        }

        public sealed class DeviceType
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

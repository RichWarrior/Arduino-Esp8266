using System.Collections.Generic;

namespace Arduino.API.Dto.Response.Device
{
    public class GetAvailablePinsResponse
    {
        public List<PinItem> Pins { get; set; }

        public GetAvailablePinsResponse()
        {
            Pins = new List<PinItem>();
        }

        public sealed class PinItem
        {
            public int Id { get; set; }
            public string PinName { get; set; }
        }
    }
}

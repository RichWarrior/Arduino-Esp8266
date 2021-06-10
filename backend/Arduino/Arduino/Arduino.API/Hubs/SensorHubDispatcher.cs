using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Arduino.API.Hubs
{
    public interface ISensorHubDispatcher
    {
        Task SendData(SensorhubModel model);
    }

    public class SensorhubModel
    {
        public string UniqueKey { get; set; }
        public string DeviceDetailId { get; set; }
        public string Value { get; set; }
    }

    public class SensorHubDispatcher : ISensorHubDispatcher
    {
        private readonly IHubContext<SensorHub> hubContext;

        public SensorHubDispatcher(IHubContext<SensorHub> _hubContext)
        {
            hubContext = _hubContext;
        }

        public async Task SendData(SensorhubModel model)
        {
            
        }
    }
}

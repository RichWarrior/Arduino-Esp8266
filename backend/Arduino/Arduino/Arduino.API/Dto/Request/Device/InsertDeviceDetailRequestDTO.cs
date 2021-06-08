using FluentValidation;

namespace Arduino.API.Dto.Request.Device
{
    /// <summary>
    /// 
    /// </summary>
    public class InsertDeviceDetailRequestDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public int DeviceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SensorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PinId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Desciption { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class InsertDeviceDetailValidator : AbstractValidator<InsertDeviceDetailRequestDTO>
    {
        public InsertDeviceDetailValidator()
        {
            RuleFor(f => f.DeviceId).GreaterThan(0);
            RuleFor(f => f.SensorId).GreaterThan(0);
            RuleFor(f => f.PinId).GreaterThan(0);
        }
    }
}

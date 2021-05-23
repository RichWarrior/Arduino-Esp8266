using FluentValidation;

namespace Arduino.API.Dto.Request.Device
{
    /// <summary>
    /// 
    /// </summary>
    public class InsertDeviceRequestDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int DeviceTypeId { get; set; }
    }

    public class InsertDeviceRequestValidator : AbstractValidator<InsertDeviceRequestDTO>
    {
        public InsertDeviceRequestValidator()
        {
            RuleFor(f => f.Name).NotEmpty().MaximumLength(255);
            RuleFor(f => f.DeviceTypeId).GreaterThan(0);
        }
    }
}

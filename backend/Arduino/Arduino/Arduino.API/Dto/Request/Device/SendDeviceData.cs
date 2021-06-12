using FluentValidation;

namespace Arduino.API.Dto.Request.Device
{
    public class SendDeviceDataRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UniqueKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int DeviceDetailId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Data { get; set; }
    }

    public class SendDeviceDataRequestValidator : AbstractValidator<SendDeviceDataRequest>
    {
        public SendDeviceDataRequestValidator()
        {
            RuleFor(f => f.UniqueKey).NotEmpty();
            RuleFor(f => f.DeviceDetailId).GreaterThan(0);
            RuleFor(f => f.Data).NotEmpty();
        }
    }
}

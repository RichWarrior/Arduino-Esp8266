using FluentValidation;

namespace Arduino.API.Dto.Request.Device
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateDeviceRequestDTO
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

    /// <summary>
    /// 
    /// </summary>
    public class UpdateDeviceRequestValidator : AbstractValidator<UpdateDeviceRequestDTO>
    {
        public UpdateDeviceRequestValidator()
        {
            RuleFor(f => f.Id).GreaterThan(0);
            RuleFor(f => f.Name).NotEmpty().MaximumLength(255);
        }
    }
}

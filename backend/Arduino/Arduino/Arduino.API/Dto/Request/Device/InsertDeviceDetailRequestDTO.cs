using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

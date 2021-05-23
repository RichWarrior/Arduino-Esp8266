using Arduino.API.Dto.Request.Device;
using Arduino.API.Dto.Response.Device;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arduino.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : BaseController
    {
        public DeviceController(
            IUnitOfWork _uow,
            IMapper _mapper,
            IStringLocalizer<BaseResource> _baseLocalizer)
            : base(_uow, _mapper, _baseLocalizer)
        {
        }

        [NonAction]
        public Device GetDevice(int id)
        {
            Device dev = null;
            var currentUser = CurrentUser;

            var device = uow.Device.FindById(id);
            if (device.Success)
                dev = device.Data;

            return dev;
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            ListDeviceResponse response = new ListDeviceResponse();

            var devices = uow.Device.GetDevices(CurrentUserId);

            if (!devices.Success)
                return NotFound(response, devices.Message);

            response.Devices = devices.Data.Select(f => new ListDeviceResponse.Device
            {
                Id = f.Id,
                Name = f.Name,
                DeviceTypeName = f.DeviceTypeName
            }).ToList();

            return Ok(response);
        }

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] InsertDeviceRequestDTO dto)
        {
            InsertDeviceResponse response = new InsertDeviceResponse();

            var deviceTypeExists = uow.DeviceType.FindById(dto.DeviceTypeId);

            if (!deviceTypeExists.Success)
                return NotFound(response, deviceTypeExists.Message);

            var currentUser = CurrentUser;
            var device = mapper.Map<Device>(dto);
            device.UserId = currentUser.Id;
            device.DeviceKey = Guid.NewGuid().ToString();
            device.CreatorId = currentUser.Id;

            var deviceCreated = uow.Device.Insert(device);
            if (!deviceCreated.Success)
                return NotFound(response, deviceCreated.Message);

            if (!uow.Commit())
                return NotFound(response);

            response.DeviceId = device.Id;

            return Ok(response);
        }

        [HttpDelete("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            DeleteDeviceResponse response = new DeleteDeviceResponse();

            var device = GetDevice(id);

            if (device == null)
                return NotFound(response);

            var isDeleted = uow.Device.Delete(device);
            if (!isDeleted.Success)
                return NotFound(response, isDeleted.Message);

            if (!uow.Commit())
                return NotFound(response);

            response.IsDeleted = isDeleted.Success;

            return Ok(response);
        }
    }
}

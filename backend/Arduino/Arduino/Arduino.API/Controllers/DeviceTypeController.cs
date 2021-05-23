using Arduino.API.Dto.Response.DeviceType;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Linq;

namespace Arduino.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceTypeController : BaseController
    {
        public DeviceTypeController(
            IUnitOfWork _uow,
            IMapper _mapper,
            IStringLocalizer<BaseResource> _baseLocalizer)
            : base(_uow, _mapper, _baseLocalizer)
        {
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            ListResponse response = new ListResponse();

            var deviceTypes = uow.DeviceType.List();

            response.DeviceTypes = deviceTypes.Data.Select(f => new ListResponse.DeviceType
            {
                Id = f.Id,
                Name = f.Name
            }).ToList();

            return Ok(response);
        }
    }
}

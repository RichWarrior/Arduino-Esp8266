using AutoMapper;
using Core.Interfaces;
using Microsoft.Extensions.Localization;

namespace Arduino.API.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(
            IUnitOfWork _uow,
            IMapper _mapper,
            IStringLocalizer<BaseResource> _baseLocalizer
            ) 
            : base(_uow, _mapper, _baseLocalizer)
        {
        }
    }
}

using FluentValidation;

namespace Arduino.API.Dto.Request.Auth
{
    /// <summary>
    /// 
    /// </summary>
    public class LogInRequestDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
    }

    public class LogInRequestValidator: AbstractValidator<LogInRequestDTO>
    {
        public LogInRequestValidator()
        {
            RuleFor(f => f.Email).NotEmpty().EmailAddress();
            RuleFor(f => f.Password).NotEmpty().MaximumLength(50);
        }
    }
}

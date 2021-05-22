using FluentValidation;

namespace Arduino.API.Dto.Request.Auth
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterRequestDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class RegisterRequestValidator : AbstractValidator<RegisterRequestDTO>
    {
        public RegisterRequestValidator()
        {
            RuleFor(f => f.Name).NotEmpty().MaximumLength(50);
            RuleFor(f => f.Surname).NotEmpty().MaximumLength(255);
            RuleFor(f => f.Email).NotEmpty().EmailAddress();
            RuleFor(f => f.Password).NotEmpty();
        }
    }
}

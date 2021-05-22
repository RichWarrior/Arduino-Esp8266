using System;

namespace Arduino.API.Dto.Response.Auth
{
    /// <summary>
    /// 
    /// </summary>
    public class LogInResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
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
        public string Token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ExpireDate { get; set; }
    }
}

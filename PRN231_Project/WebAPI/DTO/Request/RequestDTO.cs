using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO.Request
{
    public class FacebookLoginRequestDTO
    {
        public string Email { get; set; }
        public string FacebookUID { get; set; }
        public string Name { get; set; }
    }
    public class ChangePasswordRequestDTO
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string RePassword { get; set; }
    }
    public class ForgotPasswordRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
    public class LoginRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class SignupRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Username { get; set; }
    }
    public class VerifyCodeRequestDTO
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
    public class CreateVerifyCodeDTO
    {
        public string Email { get; set; }
    }
}

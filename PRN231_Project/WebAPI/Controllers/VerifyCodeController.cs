using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using WebAPI.DTO.Request;
using WebAPI.IRepository;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerifyCodeController : ControllerBase
    {
        private IVerifyCodeRepository repository;
        private IUserRepository userRepository;
        public VerifyCodeController(IVerifyCodeRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
        }
        [HttpPost("create")]
        public IActionResult CreateVerifyCode([FromBody] CreateVerifyCodeDTO request)
        {
            try
            {
                User user = userRepository.GetUserByEmail(request.Email).FirstOrDefault();
                if (user == null)
                    return NotFound();
                VerifyCode code = repository.CreateVerifyCode(user.UserId);
                string to = user.Email;
                string subject = "CloudStreaming Verify Code";
                string body = $"This is your verify code {code.Code}. This code will expire in 5 minutes!";
                Task.Run(() => Helper.MailService.Instance.SendEmail(to, body, subject));
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        [HttpPost("resend")]
        public IActionResult ResendVerifyCode([FromBody] CreateVerifyCodeDTO request)
        {
            try
            {
                User user = userRepository.GetUserByEmail(request.Email).FirstOrDefault();
                if (user == null)
                    return NotFound();
                VerifyCode code = repository.GetVerifyCode(user.UserId);
                if (code == null)
                {
                    code = repository.CreateVerifyCode(user.UserId);
                }
                string to = user.Email;
                string subject = "CloudStreaming Verify Code";
                string body = $"This is your verify code {code.Code}. This code will expire in 5 minutes!";
                Task.Run(() => Helper.MailService.Instance.SendEmail(to, body, subject));
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        [HttpPost("verify")]
        public IActionResult VerifyCode([FromBody] VerifyCodeRequestDTO request)
        {
            try
            {
                User user = userRepository.GetUserByEmail(request.Email).FirstOrDefault();
                if (user == null)
                    return NotFound();
                bool valid = repository.CodeValid(user.UserId, request.Code);
                if (!valid)
                    return NotFound();
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}

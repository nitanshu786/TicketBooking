using AutoMapper;
using Booking.Model;
using Booking.Model.DTO;
using Booking.Repository;
using Booking.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterAPIController : ControllerBase
    {
        private readonly IRegister _register;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        public RegisterAPIController(IRegister register, IEmailSender emailSender, IMapper mapper)
        {
            _register = register;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO register )
        {
            if (ModelState.IsValid)
            {
               if(register.Email!=null)
                {
                    _emailSender.SendEmailAsync(register.Email, "This is test email subject from Booking Team");
                }
                //var reg = _register.IsUniqueUser(registerVM.Name, registerVM.Email);
                //if (!reg) return BadRequest("Username already exist please try new username");
                var logs = _mapper.Map<RegisterDTO, RegisterVM>(register);
                
                var enc = _register.Registers(logs);
               
                if (enc == null) return BadRequest();
                else
                    return Ok(enc);
            }
            return Ok();
            //

        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserDTO uservm)
        {

            var user = _mapper.Map<UserDTO, UserVM>(uservm);


            var log = _register.Login(user.Email, Encryption(user.Password));
            if (log == null) return BadRequest("wrong username & passward please enter valid usename & passward");

            return Ok(log);
        }
        public static string Encryption(string password)
        {
            if (string.IsNullOrEmpty(password))
                return null;
            else
            {
                byte[] storepassword = Encoding.ASCII.GetBytes(password);
                string encryption = Convert.ToBase64String(storepassword);
                return encryption;
            }
        }
        

    }
}

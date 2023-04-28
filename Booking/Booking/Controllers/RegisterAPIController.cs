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
        [HttpPost("email")]
        public IActionResult Email([FromBody] RegisterVM registerVM)
        {
            if (registerVM.Email != null)
            {
                _emailSender.SendEmailAsync(registerVM.Email, "This is test email subject from Booking Team");
            }
            return Ok(registerVM);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterVM register )
        {
            if (ModelState.IsValid)
            {
               
                var reg = _register.IsUniqueUser(register.Name, register.Email);
                if (!reg) return BadRequest("Username already exist please try new username");
                var logs = _mapper.Map<RegisterVM, UserDTO>(register);

                var enc = _register.Registers(logs);
               
                if (enc == null) return BadRequest();
                else
                    return Ok(enc);
            }
            return Ok();
            //

        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {

            var user = _mapper.Map<LoginDTO, UserTable >(login);


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

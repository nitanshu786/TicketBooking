using Booking.Data;
using Booking.Model;
using Booking.Model.DTO;
using Booking.Repository.IRepository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository
{
    public class RegisterUser : IRegister
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtToken _jwtToken;
        public RegisterUser(ApplicationDbContext context, IOptions<JwtToken> jwttoken)
        {
            _context = context;
            _jwtToken = jwttoken.Value;
        }


        public UserTable Login(string Email, string Passward)
        {
            var auth = _context.UserTables.FirstOrDefault(s => s.Email == Email && s.Password == Passward);
            if (auth == null)
                return null;

            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtToken.Secret);
                var tokenDescritor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, auth.Id.ToString())


                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescritor);
                auth.Token = tokenHandler.WriteToken(token);
                return auth;
            }
        }

        public UserTable Registers(UserDTO userDTO)
        {

            var user = new UserTable()
            {
                Name = userDTO.Name,

                Email = userDTO.Email,
                Address = userDTO.Address,
              
                RegisterDate = DateTime.Now,
                ExpireDate = DateTime.Today.AddDays(2),
                RefreshDates= DateTime.Now,
                 Role= "User"
                    
                };
               
                _context.UserTables.Add(user);
            _context.SaveChanges();
            return user;

           
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

        public bool IsUniqueUser( string email)
        {
            
            
                var uniq = _context.UserTables.FirstOrDefault(s =>  s.Email==email);

                if (uniq == null)
                {
                    return true;
                }
                else
                    return false;
            }

        public UserTable UpdateRegister(UserTable userTable)
        {
          
            var find = _context.UserTables.FirstOrDefault(s => s.Id == userTable.Id );
            if (find != null)
                find.Password = Encryption(userTable.Password);
              
                _context.UserTables.Update(find);
                _context.SaveChanges();
            return find;
            
            
               
           
            
        }
    }
    
}

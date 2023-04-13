using Booking.Data;
using Booking.Model;
using Booking.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository
{
    public class RegisterUser : IRegister
    {
        private readonly ApplicationDbContext _context;

        public RegisterUser(ApplicationDbContext context)
        {
            _context = context;
        }

     
        public UserTable Login(string Email, string Passward)
        {
            var auth = _context.UserTables.FirstOrDefault(s => s.Email == Email && s. Password==Passward );
          

            //if (auth == null)
            //    return null;


            //else
            //{
            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var key = Encoding.ASCII.GetBytes(_jwtToken.Secret);
            //    var tokenDescritor = new SecurityTokenDescriptor()
            //    {
            //        Subject = new ClaimsIdentity(new Claim[]
            //        {
            //        new Claim(ClaimTypes.Name, auth.Id.ToString())


            //        }),
            //        Expires = DateTime.UtcNow.AddDays(7),
            //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            //        SecurityAlgorithms.HmacSha256Signature)
            //    };

            //    var token = tokenHandler.CreateToken(tokenDescritor);
            //    auth.Token = tokenHandler.WriteToken(token);
                return auth;
            }

        public UserTable Registers(RegisterVM registerVM)
        {

            var user = new UserTable()
            {
                Name = registerVM.Name,

                Email = registerVM.Email,
                Address = registerVM.Address,
                RegisterDate = registerVM.RegisterDate,
                RoleId = registerVM.RoleId=2
                    
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

        public bool IsUniqueUser(string Name, string email)
        {
            
            
                var uniq = _context.UserTables.FirstOrDefault(s => s.Name == Name && s.Email==email);

                if (uniq == null)
                {
                    return true;
                }
                else
                    return false;
            }
        }
    
}

using APP.DAL.Entities;
using APP.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Repository
{
    public class UserDAL : IUserDAL
    {
        private readonly StudioDbContext db;
        private readonly string filePath;
        private readonly IConfiguration myConfig;
        public UserDAL()
        {
            db = new StudioDbContext();

            filePath = @"C:\Users\LakshmanSivarathan\OneDrive - Rizing LLC\Documents\StudioBackend\Server\APP.PL\appSettings.json";

            myConfig = new ConfigurationBuilder()
           .SetBasePath(Path.GetDirectoryName(filePath))
           .AddJsonFile("appSettings.json")
           .Build();
        }

        public User Login(User user)
        {
            User resultLoginCheck = db.Users
                    .Where(e => e.Email == user.Email && e.Password == user.Password)
                    .FirstOrDefault();
            
                if (resultLoginCheck == null)
                {
                    throw new Exception("Invalid Credentials");
                }
                else
                {
                    var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("UserId", resultLoginCheck.Id.ToString()),
                            new Claim("Email", user.Email)
                        };


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(myConfig.GetValue<string>("Jwt:Key")));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        myConfig.GetValue<string>("Jwt:Issuer"),
                        myConfig.GetValue<string>("Jwt:Audience"),
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                        signingCredentials: signIn);


                    user.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return user;
                }
            

        }

        public int ChangePassword(User user)
        {
            User result = db.Users
                    .Where(e => e.Email == user.Email && e.Password == user.Password)
                    .FirstOrDefault();

            if (result == null)
            {
                throw new Exception("User Not Found");
            }
            else
            {
                result.Password = user.NewPassword;
                db.Users.Update(result);
                db.SaveChanges();
            }

            return result.Id;

        }

        public User GetUser(string token)
        {
            var JWTtoken = new JwtSecurityToken(token);
            var UID = Int32.Parse(JWTtoken.Claims.First(c => c.Type == "UserId").Value);
            User result = db.Users
                    .Where(e => e.Id == UID)
                    .FirstOrDefault();

            if (result == null)
            {
                throw new Exception("User Not Found");
            }
            else
            {
                var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("UserId", result.Id.ToString()),
                            new Claim("Email", result.Email)
                        };


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(myConfig.GetValue<string>("Jwt:Key")));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var newToken = new JwtSecurityToken(
                    myConfig.GetValue<string>("Jwt:Issuer"),
                    myConfig.GetValue<string>("Jwt:Audience"),
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: signIn);


                result.AccessToken = new JwtSecurityTokenHandler().WriteToken(newToken);

                return result;
            }


        }
    }
}

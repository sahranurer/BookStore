using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entities;
using WebApi.TokenOperations.Models;

namespace WebApi.TokenOperations
{
    public class TokenHandler{

        public IConfiguration Configuration {get;set;}
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }



      public Token CreateAccessToken(User user){
         Token tokenModel = new Token();
         SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])) ;
         SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
         tokenModel.Expiration = DateTime.Now.AddMinutes(15);   
//token özellikleri
         JwtSecurityToken securityToken = new JwtSecurityToken(
             issuer:Configuration["Token:Issuer"],
             audience:Configuration["Token:Audience"],
             expires:tokenModel.Expiration,
             notBefore:DateTime.Now,
             signingCredentials : credentials

         );
//token üretilmesi
         JwtSecurityTokenHandler tokenhandler = new JwtSecurityTokenHandler();

         tokenModel.AccessToken = tokenhandler.WriteToken(securityToken);
         tokenModel.RefreshToken = CreateRefreshToken();
         return tokenModel;




      }
//yeniden token yenileme
      public string CreateRefreshToken(){
          return Guid.NewGuid().ToString();
      }


    }
    
}
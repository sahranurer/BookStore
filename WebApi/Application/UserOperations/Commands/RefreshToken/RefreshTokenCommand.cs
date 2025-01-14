using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.UserOperations.Commands.RefreshToken{
    public class RefreshTokenCommand{
        public string RefreshToken{get;set;}
        private readonly IBookStoreDbContext _dbContext;
       
        readonly IConfiguration _configuration;
        public RefreshTokenCommand(IBookStoreDbContext dbContext,IConfiguration configuration){
           _dbContext = dbContext;
           _configuration = configuration;
        }

       public Token Handle(){
           var user = _dbContext.Users.FirstOrDefault(x=>x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
           if(user is not null){
               //token yarat
               TokenHandler handler = new TokenHandler(_configuration);
               Token token = handler.CreateAccessToken(user);
               user.RefreshToken = token.RefreshToken;
               user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
               _dbContext.SaveChanges();
               return token;
           }
           else 
             throw new InvalidOperationException("Validate bir refresh token bulunamadı");
       }
    }

}

using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encyption;
using IFSE.Business.Utilities.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configration { get;  }
        private  TokenOptions _tokenOptions;
        public DateTime _accesTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configration = configuration;
            _tokenOptions = Configration.GetSection("TokenOptions").Get<TokenOptions>();
           
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accesTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions,user, signingCredentials,operationClaims);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            
            return new AccessToken {Token= token,Expiration=_accesTokenExpiration };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user,
             SigningCredentials signingCredentials,List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                    issuer:tokenOptions.Issuer,
                    audience:tokenOptions.Audience,
                    expires: _accesTokenExpiration,
                    notBefore:DateTime.Now,
                    claims: SetClaims(user,operationClaims),
                    signingCredentials:signingCredentials
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;

        }

        public AccessToken CreateToken(EsitUser esitUser)
        {
            _accesTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, esitUser, signingCredentials);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken { Token = token, Expiration = _accesTokenExpiration };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, EsitUser esitUser,  SigningCredentials signingCredentials )
        {
            var jwt = new JwtSecurityToken(
                    issuer: tokenOptions.Issuer,
                    audience: tokenOptions.Audience,
                    expires: _accesTokenExpiration,
                    notBefore: DateTime.Now,
                    claims: SetClaims(esitUser),
                    signingCredentials: signingCredentials
                );
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(EsitUser esitUser)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(esitUser.UserName);
            claims.AddUserData(esitUser.Ip);
            claims.AddRoles(new string[] { "admin"});//bu kısım geliştirilebilir
            return claims;
        }
       
    }
}


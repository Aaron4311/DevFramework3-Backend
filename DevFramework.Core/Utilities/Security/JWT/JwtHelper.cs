using Microsoft.Extensions.Configuration;
using DevFramework.Core.Entity.Concrete;
using DevFramework.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Utilities.Security.Encryption;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using DevFramework.Core.Extensions;
using System.Net;

namespace DevFramework.Core.Utilities.Security.JWT
{
	public class JwtHelper : ITokenHelper
	{
		public IConfiguration Configuration { get; }
		private TokenOptions _tokenOptions;
		private DateTime _expiration;

		public JwtHelper(IConfiguration configuration)
		{
			Configuration = configuration;
			_tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

		}

		public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
		{
			_expiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
			var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
			var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
			var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
			var jwtSecurityToken = new JwtSecurityTokenHandler();
			var token = jwtSecurityToken.WriteToken(jwt);
			return new AccessToken
			{
				Token = token,
				Expiration = _expiration,
			};

		}

		public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
			SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
		{

			var jwt = new JwtSecurityToken(
				audience: tokenOptions.Audience,
				issuer: tokenOptions.Issuer,
				expires: _expiration,
				notBefore: DateTime.Now,
				signingCredentials: signingCredentials,
				claims: SetClaims(user, operationClaims)
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
	}
}

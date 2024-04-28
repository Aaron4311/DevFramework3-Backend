using DevFramework.Core.Entity.Concrete;
using DevFramework.Core.Utilities.Results;
using DevFramework.Core.Utilities.Security.JWT;
using DevFramework.Northwind.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.Abstract
{
	public interface IAuthService
	{
		IDataResult<User> Register(UserForRegisterDto userForRegisterDto,string password);
		IDataResult<User> Login(UserForLoginDto userForLoginDto);
		IResult UserExists(string email);
		IDataResult<AccessToken> CreateAccessToken(User user);
	}
}

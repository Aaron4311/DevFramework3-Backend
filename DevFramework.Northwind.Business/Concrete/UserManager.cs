using DevFramework.Core.Aspects.Autofac.Validation;
using DevFramework.Core.Entity.Concrete;
using DevFramework.Core.Utilities.Results;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.BusinessAspects.Autofac;
using DevFramework.Northwind.Business.Constants;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;

namespace DevFramework.Northwind.Business.Concrete
{
	public class UserManager : IUserService
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		[ValidationAspect(typeof(UserValidator))]
		[SecuredOperation("admin")]
		public IResult Add(User user)
		{
			_userDal.Add(user);
			return new SuccessResult(Messages.UserAdded);
		}

		public IDataResult<User> GetByMail(string mail)
		{
			return new SuccessDataResult<User>(_userDal.Get(x => x.Email == mail));
		}

		public List<OperationClaim> GetClaims(User user)
		{
			return _userDal.GetClaims(user);
		}
	}
}

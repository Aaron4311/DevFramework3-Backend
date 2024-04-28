using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Core.Entity.Concrete;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Context;
using DevFramework.Northwind.DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework
{
	public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
	{
		public List<OperationClaim> GetClaims(User user)
		{
			using (var context = new NorthwindContext())
			{
				var result = from operationClaim in context.OperationClaims
							 join userOperationClaim in context.UserOperationClaims on operationClaim.Id equals userOperationClaim.OperationClaimId
							 where userOperationClaim.UserId == user.Id
							 select new OperationClaim
							 {
								 Id = operationClaim.Id,
								 Name = operationClaim.Name,
							 };
				return result.ToList();
			}
		}
	}
}

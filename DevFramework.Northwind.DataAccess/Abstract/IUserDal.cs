using DevFramework.Core.DataAccess;
using DevFramework.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Abstract
{
	public interface IUserDal : IEntityRepository<User>
	{
		public List<OperationClaim> GetClaims(User user);
	}
}

﻿using DevFramework.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Utilities.Security.JWT
{
	public interface ITokenHelper 
	{
		AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
	}
}

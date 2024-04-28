using Castle.DynamicProxy;
using DevFramework.Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DevFramework.Core.Aspects.Autofac.Performance
{
	public class TransactionAspect : MethodInterception
	{
		public override void Intercept(IInvocation invocation)
		{
			using (TransactionScope transactionScope = new TransactionScope())
			{
				try
				{
					invocation.Proceed();
				}
				catch (System.Exception)
				{

					transactionScope.Dispose();
					throw;
				}
			}
		}
	}
}

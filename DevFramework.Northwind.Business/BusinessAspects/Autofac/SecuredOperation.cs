using Castle.DynamicProxy;
using DevFramework.Core.Extensions;
using DevFramework.Core.Utilities.Interceptors;
using DevFramework.Core.Utilities.IoC;
using DevFramework.Northwind.Business.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DevFramework.Northwind.Business.BusinessAspects.Autofac
{
	public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

		public SecuredOperation(string roles)
		{
			_roles = roles.Split(',');
			_httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
		}
		public override void OnBefore(IInvocation invocation)
		{
			var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
			foreach (var role in _roles)
			{
				if (roleClaims.Contains(role))
				{
					return;
				}

			}
			throw new Exception(Messages.AuthorizationDenied);
		}
	}
}

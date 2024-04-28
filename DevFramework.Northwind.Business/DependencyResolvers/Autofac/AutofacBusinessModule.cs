using Autofac;
using Autofac.Extras.DynamicProxy;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.Concrete;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Castle.DynamicProxy;


using System.Reflection;
using Module = Autofac.Module;
using DevFramework.Core.Utilities.Interceptors;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using DevFramework.Core.Utilities.Security.JWT;
namespace DevFramework.Northwind.Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
			builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

			builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();

			builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
			builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
			
			builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
			builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

			var assembly = Assembly.GetExecutingAssembly();
			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
				.EnableInterfaceInterceptors(new ProxyGenerationOptions()
				{
					Selector = new AspectInterceptorSelector()
				}).SingleInstance();

		}
	}
}

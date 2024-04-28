using Castle.DynamicProxy;
using DevFramework.Core.Aspects.Autofac.Exception;
using DevFramework.Core.Aspects.Autofac.Logging;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Utilities.Interceptors
{
	public class AspectInterceptorSelector : IInterceptorSelector
	{
		public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
		{
			var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
			var methodAttribute = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
			classAttributes.AddRange(methodAttribute);
			classAttributes.Add(new ExceptionAspect(typeof(FileLogger)));
			classAttributes.Add(new ExceptionAspect(typeof(DatabaseLogger)));

			classAttributes.Add(new LogAspect(typeof(FileLogger)));
			classAttributes.Add(new LogAspect(typeof(DatabaseLogger)));


			return classAttributes.OrderBy(x => x.Priority).ToArray();

		}
	}
}

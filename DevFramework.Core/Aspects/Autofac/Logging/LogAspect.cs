using Castle.DynamicProxy;
using DevFramework.Core.CrossCuttingConcerns.Logging;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using DevFramework.Core.Utilities.AspectMessages;
using DevFramework.Core.Utilities.Interceptors;

namespace DevFramework.Core.Aspects.Autofac.Logging
{
	public class LogAspect :MethodInterception
	{
		private LoggerServiceBase _logger;

		public LogAspect(Type logger)
		{
			if (logger.BaseType!=typeof(LoggerServiceBase))
			{
				throw new System.Exception(AspectMessages.WrongLogger);
			}
			_logger = (LoggerServiceBase)Activator.CreateInstance(logger);
		}
		public override void OnBefore(IInvocation invocation)
		{
			_logger.Info(GetLogDetail(invocation));
		}

		private LogDetail GetLogDetail(IInvocation invocation)
		{
			var logParameters = new List<LogParameter>();
			for (int i = 0; i < invocation.Arguments.Length; i++)
			{
				logParameters.Add(new LogParameter
				{
					Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
					Value = invocation.Arguments[i],
					Type = invocation.Arguments[i].GetType().Name
				});
			}

			var logDetail = new LogDetail
			{
				MethodName = invocation.Method.Name,
				LogParameters = logParameters
			};

			return logDetail;
		}
	}
}

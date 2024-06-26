﻿using Castle.DynamicProxy;
using DevFramework.Core.CrossCuttingConcerns.Logging;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using DevFramework.Core.Utilities.AspectMessages;
using DevFramework.Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Autofac.Exception
{
	public class ExceptionAspect : MethodInterception
	{
		private LoggerServiceBase _loggerServiceBase;

		public ExceptionAspect(Type loggerService)
		{
			if (loggerService.BaseType != typeof(LoggerServiceBase))
			{
				throw new System.Exception(AspectMessages.WrongLoggerType);
			}
			_loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
		}
		public override void OnException(IInvocation invocation, System.Exception e)
		{
			LogDetailWithException logDetailWithException = GetLogDetail(invocation);
			logDetailWithException.ExceptionMessage = e.Message;
			_loggerServiceBase.Error(logDetailWithException);
		}

		private LogDetailWithException GetLogDetail(IInvocation invocation)
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
			var logDetailWithException = new LogDetailWithException
			{
				MethodName = invocation.Method.Name,
				LogParameters = logParameters
			};
			return logDetailWithException;
		}
	}
}

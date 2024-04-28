﻿using Castle.DynamicProxy;
using DevFramework.Core.CrossCuttingConcerns.Caching;
using DevFramework.Core.Utilities.Interceptors;
using DevFramework.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Autofac.Caching
{
	public class CacheRemoveAspect : MethodInterception
	{
		private string _pattern;
		private ICacheManager _cacheManager;

		public CacheRemoveAspect(string pattern)
		{
			_cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
			_pattern = pattern;

		}

		public override void OnSuccess(IInvocation invocation)
		{
			_cacheManager.RemoveByPattern(_pattern);
		}

	}
}

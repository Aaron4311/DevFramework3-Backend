using DevFramework.Core.CrossCuttingConcerns.Caching;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DependencyResolvers
{
	public class CoreModule : ICoreModule
	{
		public void Load(IServiceCollection collection)
		{
			collection.AddMemoryCache();
			collection.AddSingleton<ICacheManager, MemoryCacheManager>();
			collection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			collection.AddSingleton<Stopwatch>();
		}
	}
}

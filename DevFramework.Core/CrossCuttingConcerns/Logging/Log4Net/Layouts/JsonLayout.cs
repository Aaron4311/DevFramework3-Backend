﻿using log4net.Core;
using log4net.Layout;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts
{
	public class JsonLayout : LayoutSkeleton
	{
		public override void ActivateOptions()
		{
			
		}

		public override void Format(TextWriter writer, LoggingEvent loggingEvent)
		{
			var logEvent = new SerializableLogEvent(loggingEvent);
			var json = JsonConvert.SerializeObject(logEvent,Formatting.Indented);
			writer.WriteLine(json);
		}
	}
}

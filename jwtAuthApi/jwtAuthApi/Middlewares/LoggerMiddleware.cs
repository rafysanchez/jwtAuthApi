﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace jwtAuthApi.Application.Middlewares
{
    public static class LoggerMiddleware
    {
        public static void AddLoggerMiddleware(this IServiceCollection services)
        {
            var logger = UseJwtMiddleware(services);

            logger.Write(LogEventLevel.Information, "Application initialized");
        }

        private static Logger UseJwtMiddleware(IServiceCollection services)
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile(@"log.txt",
                    retainedFileCountLimit: 8, fileSizeLimitBytes: 409600)
                .CreateLogger();

            return logger;
        }
    }
}

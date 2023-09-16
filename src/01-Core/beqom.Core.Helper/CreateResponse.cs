﻿using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace beqom.Core.Helper
{
    public static class CreateResponse<T> where T : class
    {
        public static ResponseDTO<T> Return(T entity, string methodName)
        {

            string message = string.Empty;
            if (entity != null)
                message = GetDescription(ResponseCodes.Success);
            else
                message = GetDescription(ResponseCodes.NotFound);
            ResponseDTO<T> response = new ResponseDTO<T>
            {
                Data = entity,
                Message = message,
                Information = new Information
                {
                    TrackId = Guid.NewGuid().ToString()
                },
                RC = entity == null ? ResponseCodes.NotFound : ResponseCodes.Success
            };
            Log.Write(LogEventLevel.Information, message, response);
            return response;
        }

        public static ResponseListDTO<T> Return(IEnumerable<T> entity, string methodName)
        {
            string message = string.Empty;
            if (entity.Count() > 0)
                message = GetDescription(ResponseCodes.Success);
            else
                message = GetDescription(ResponseCodes.NotFound);

            ResponseListDTO<T> response = new ResponseListDTO<T>
            {
                Data = entity,
                Message = message,
                Information = new Information
                {
                    TrackId = Guid.NewGuid().ToString()
                },
                RC = entity == null ? ResponseCodes.NotFound : ResponseCodes.Success
            };
            Log.Write(LogEventLevel.Information, message, response);
            return response;
        }
        public static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        }
        public static string GetDescription(string RC)
        {
            IConfiguration config = GetConfiguration();
            return config.GetSection("ResponseCodes:" + RC).Get<string>();
        }
    }
}

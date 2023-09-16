using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace beqom.Presentation.API.Extensions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string message)
        {
            RC = message;
        }

        public string RC { get; set; }

        public static string PrepareDescription(string RC)
        {
            return GetDescription(RC);
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
﻿using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace beqom.Domain.Aggregate
{
    public static class Extensions
    {
        public static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        }
        public static Option.Entities.Option GetOption(string optionName)
        {
            IConfiguration config = GetConfiguration();
            var response = new Option.Entities.Option();
            response.Id = config.GetSection(optionName + ":Id").Get<Guid>();
            response.Name = config.GetSection(optionName + ":Name").Get<string>();
            response.Status = config.GetSection(optionName + ":Status").Get<bool>();
            response.IsActive = config.GetSection(optionName + ":IsActive").Get<bool>();
            return response;
        }

        public static bool HasValue(this Option.Entities.Option option)
        {
            if (option.Id == Guid.Empty && string.IsNullOrEmpty(option.Name))
                return false;

            return true;
        }

        public static bool IsSame(this Option.Entities.Option option, Option.Entities.Option compared)
        {
            if (option.Id == compared.Id && option.Name == compared.Name && option.IsActive == compared.IsActive && option.Status == compared.Status)
                return true;

            return false;
        }

        public static Option.Entities.Option ValueOr(this Option.Entities.Option option, Func<Option.Entities.Option> function)
        {
            return option;
        }

        public static object ValueOr(this object option, Func<object> function)
        {
            return option;
        }

        public static Option.Entities.Option Select(this Option.Entities.Option option, Func<Option.Entities.Option, Option.Entities.Option> p)
        {
            if (option is null)
                return null;

            return option;
        }
    }
}

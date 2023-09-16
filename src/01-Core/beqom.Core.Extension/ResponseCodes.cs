using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beqom.Core.Extension
{
    public struct ResponseCodes
    {
        public const string Success = "RC0000";
        public const string NotNullable = "RC0001";
        public const string Failed = "RC0002";
        public const string NotFound = "RC0003";
        public const string Unauthorized = "RC0004";
        public const string BadRequest = "RC0005";
    }
}

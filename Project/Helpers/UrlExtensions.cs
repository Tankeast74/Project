using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Helpers
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request)
        {
            string result;

            if (request.QueryString.HasValue)
                result = $"{request.Path}{request.QueryString}";
            else
                result = request.Path.ToString();

            return result;
        }
    }
}

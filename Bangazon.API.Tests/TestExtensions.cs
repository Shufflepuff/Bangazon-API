using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon.API.Tests
{
    internal static class TestExtensions
    {
        public static T GetContentValue<T>(this HttpResponseMessage response)
        {
            T content;
            if (response.TryGetContentValue(out content))
            {
                return content;
            }
            return default(T);
        }
    }
}

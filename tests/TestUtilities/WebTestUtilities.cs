using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.Internal;
using Moq;

namespace TestUtilities
{
    public static class WebTestUtilities
    {
        public static IHttpContextAccessor CreateMockHttpContextAccessor
            (IHeaderDictionary requestValues, IHeaderDictionary responseValues, string remoteAddress
            ,string requestPath, string queryString)
        {
            var retval = new Mock<IHttpContextAccessor>();

            HttpContext httpContext = new DefaultHttpContext();

            
            IPAddress address = IPAddress.Parse("192.168.1.1");
            httpContext.Connection.RemoteIpAddress = address;
            
            httpContext.Request.Path = requestPath;
            httpContext.Request.QueryString = new QueryString(queryString);

            if (requestValues.Count > 0)
            {
                foreach (var key in requestValues.Keys)
                {
                    httpContext.Request.Headers[key] = requestValues[key];
                }
            }

            if (responseValues.Count > 0)
            {
                foreach (var key in responseValues.Keys)
                {
                    httpContext.Response.Headers[key] = responseValues[key];
                }
            }

            retval.Setup(x => x.HttpContext).Returns(httpContext);

            return retval.Object;
        }
    }
}

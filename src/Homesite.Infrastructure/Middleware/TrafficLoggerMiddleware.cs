using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Services.Logging;
using Homesite.Application.Common.Interfaces.Services.Parameters.Logging;
using Homesite.Domain.Entities;
using Homesite.Infrastructure.Services.Parameters.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Homesite.Infrastructure.Middleware
{
    public class TrafficLoggerMiddleware
    {
        private readonly RequestDelegate next;

        public TrafficLoggerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context /* other dependencies */)
        {
            ITrafficLoggerService service = context.RequestServices.GetService<ITrafficLoggerService>();

            await service.LogTraffic(CreateLogParameter(context), CancellationToken.None);

            await next(context);
        }

        private ITrafficLogParameter CreateLogParameter(HttpContext ctx)
        {
            var parseQueryString = () =>
            {

                StringBuilder sb = new StringBuilder();

                foreach (var q in ctx.Request.Query)
                {
                    sb.AppendLine($"Name: {q.Key}, Value: {q.Value}");
                }

                return sb.ToString();

            };

            var parseRequestHeaders = () =>
            {
                StringBuilder sb = new StringBuilder();

                foreach (var hdr in ctx.Request.Headers)
                {
                    sb.AppendLine($"Name: {hdr.Key}, Value: {hdr.Value}");
                }

                return sb.ToString();
            };

            var parseRequestBody = () =>
            {
                string body = null;

                using (var mem = new MemoryStream())
                using (var reader = new StreamReader(mem))
                {
                    ctx.Request.Body.CopyTo(mem);

                    body = reader.ReadToEnd();

                    // Do something

                    mem.Seek(0, SeekOrigin.Begin);

                    body = reader.ReadToEnd();
                }
            };

            var parseRequestCookies = () =>
            {
                StringBuilder sb = new StringBuilder();

                foreach (var cookie in ctx.Request.Cookies)
                {
                    sb.AppendLine($"Name: {cookie.Key}, Value: {cookie.Value}");
                }

                return sb.ToString();
            };

            ITrafficLogParameter log = new TrafficLogParameter();

            log.Host = ctx.Request.Host.Host;
            log.LocalPort = ctx.Connection.LocalPort;
            log.RemotePort = ctx.Connection.RemotePort;
            log.RequestCookies = parseRequestCookies();
            log.RequestHeaders = parseRequestHeaders();
            log.RequestLength = ctx.Request.ContentLength;
            log.RequestMethod = ctx.Request.Method;
            log.RequestPath = ctx.Request.Path;
            log.RequestProtocol = ctx.Request.Protocol;
            log.RequestQuery = parseQueryString();
            log.RequestScheme = ctx.Request.Scheme;
            log.LocalIP = ctx.Connection.LocalIpAddress.ToString();
            log.RemoteIP = ctx.Connection.RemoteIpAddress.ToString();
            log.RequestContentType = ctx.Request.ContentType;
            log.RequestQueryString = ctx.Request.QueryString.Value;
            log.TrafficDate = DateTime.Now;

            return log;
        }

    }

    public static class TrafficLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseTrafficLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TrafficLoggerMiddleware>();
        }
    }
}

﻿using beqom.Core.Helper;
using beqom.Domain.Contract.DTO.Error;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace beqom.Presentation.API.Extensions
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                Log.Write(LogEventLevel.Information, "Service path is:" + context.Request.Path.Value,
                    context.Request.Body);
                await next(context);
            }
            catch (HttpRequestException ex)
            {
                Log.Write(LogEventLevel.Error, ex.Message, "Service path is:" + context.Request.Path.Value, ex);
                await HandleExceptionAsync(context, ex);
            }
            catch (AuthenticationException ex)
            {
                Log.Write(LogEventLevel.Error, ex.Message, "Service path is:" + context.Request.Path.Value, ex);
                await HandleExceptionAsync(context, ex);
            }
            catch (BusinessException ex)
            {
                Log.Write(LogEventLevel.Error, ex.Message, "Service path is:" + context.Request.Path.Value, ex);
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                Log.Write(LogEventLevel.Error, ex.Message, ex.Source, ex.TargetSite, ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, object exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            var message = string.Empty;
            var RC = string.Empty;

            if (exception.GetType() == typeof(HttpRequestException))
            {
                code = HttpStatusCode.NotFound;
                RC = ResponseCodes.NotFound;
                message = BusinessException.GetDescription(RC);
            }
            else if (exception.GetType() == typeof(AuthenticationException))
            {
                code = HttpStatusCode.Unauthorized;
                RC = ResponseCodes.Unauthorized;
                message = BusinessException.GetDescription(RC);
            }
            else if (exception.GetType() == typeof(BusinessException))
            {
                var businesException = (BusinessException)exception;
                message = BusinessException.GetDescription(businesException.RC);
                code = HttpStatusCode.InternalServerError;
                RC = businesException.RC;
            }
            else if (exception.GetType() == typeof(Exception))
            {
                code = HttpStatusCode.BadRequest;
                RC = ResponseCodes.BadRequest;
                message = BusinessException.GetDescription(RC);
            }

            var response = new ErrorDTO
            {
                Message = message,
                RC = RC
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
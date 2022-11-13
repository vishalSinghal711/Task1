using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace AmritERP.Behaviour.Error {
    public class ErrorHandeling {
        private readonly RequestDelegate next;
        public ErrorHandeling (RequestDelegate next) {
            this.next = next;
        }
        public async Task Invoke (HttpContext context /* other dependencies */ ) {
            try {
                await next (context);
            } catch (Exception ex) {
                await HandleExceptionAsync (context, ex);
            }
        }
        private static Task HandleExceptionAsync (HttpContext context, Exception exception) {
            // var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            // if (exception is MyNotFoundException) code = HttpStatusCode.NotFound;
            // else if (exception is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            // else if (exception is MyException) code = HttpStatusCode.BadRequest;

            // var result = JsonConvert.SerializeObject (new { error = exception.StackTrace });
            context.Response.ContentType = "application/json";

            // context.Response.StatusCode = (int) code;
            string errorMsg = exception.Message;
            string innerMessage = "" + exception.InnerException;
            string Stacktrace = exception.StackTrace;
            string Source = exception.Source;
            ErrorExtension obj = new ErrorExtension ();
            obj.errorLogger (errorMsg, innerMessage, Stacktrace, Source);
            return context.Response.WriteAsync ("Something Went Wrong");
        }

    }

}
namespace BasicProject.Api.Exceptions
{
    using System;
    using System.Data;
    using System.Net;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class ApiErrorHandler
    {
        public static bool HandleException(Exception ex, ControllerBase context, out IActionResult exceptionResult)
        {
            if (ex is DuplicateNameException)
            {
                exceptionResult = new ConflictObjectResult(ex.Message);
                return true;
            }

            if (ex.Message.Contains("not found"))
            {
                exceptionResult = new NotFoundObjectResult(ex.Message);
                return true;
            }

            if (ex is Exception)
            {
                exceptionResult = context.StatusCode(500, "Internal Server Error, please Try Again");
                return true;
            }

            exceptionResult = null;
            return false;
        }
    }
}

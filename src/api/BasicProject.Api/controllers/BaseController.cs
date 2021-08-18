namespace BasicProject.Api.controllers
{
    using BasicProject.Api.Exceptions;
    using BasicProject.Logger;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public abstract class BaseController : ControllerBase
    {
        public delegate T SimpleCommand<out T>();
        private readonly Ilogger logger;

        public BaseController(Ilogger logger)
        {
            this.logger = logger;
        }

        protected IActionResult InvokeAndReturnResult<T>(
           SimpleCommand<T> simpleCommand,
           int statusCode)
        {
            try
            {
                logger.Information("Invoking");

                var result = simpleCommand.Invoke();

                logger.Information("End Invoking");

                return this.StatusCode(statusCode, result);
            }
            catch (Exception ex)
            {
                logger.Error("Internal Error", ex);

                if (ApiErrorHandler.HandleException(ex, this, out IActionResult exceptionResult))
                {
                    return exceptionResult;
                }

                throw;
            }
        }
    }
}

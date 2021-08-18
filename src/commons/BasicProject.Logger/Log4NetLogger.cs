namespace BasicProject.Logger
{
    using log4net;
    using log4net.Config;
    using System;
    using System.Reflection;

    public class Log4NetLogger : Ilogger, IDisposable
    {
        private readonly ILog logger;

        public Log4NetLogger(Type callerType)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var repository = LogManager.GetRepository(assembly);
            var assemblyName = assembly.GetName().Name;
            var config = assembly.GetManifestResourceStream($"{assemblyName}.Logger.config");

            XmlConfigurator.Configure(repository, config);

            logger = LogManager.GetLogger(callerType);
        }

        public void Dispose()
        {
            logger.Logger.Repository.Shutdown();
        }

        public void Error(string message, Exception exception)
        {
            logger.Error(message, exception);
        }

        public void Information(string message)
        {
            logger.Info(message);
        }
    }
}

namespace BasicProject.Logger
{
    public static class LoggerFactory
    {
        private static Ilogger logger;

        public static Ilogger GetLogger<T>()
        {
            if (logger == null)
            {
                logger = new Log4NetLogger(typeof(T));
            }

            return logger;
        }
    }
}

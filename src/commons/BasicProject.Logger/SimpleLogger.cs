namespace BasicProject.Logger
{
    using System;
    using System.Diagnostics;

    public class SimpleLogger : Ilogger
    {
        public SimpleLogger()
        {
        }

        public void Error(string message, Exception exception)
        {
            var stackTrace = new StackTrace();
            var callingMethog = stackTrace.GetFrame(1).GetMethod();
            var source = callingMethog.DeclaringType.Name;

            Console.WriteLine($"{source} - ERROR {DateTime.Now}: {message}, {exception}");
        }

        public void Information(string message)
        {
            var stackTrace = new StackTrace();
            var callingMethog = stackTrace.GetFrame(1).GetMethod();
            var source = callingMethog.DeclaringType.Name;

            Console.WriteLine($"{source} - INFO: {message}");
        }
    }
}

namespace BasicProject.Logger
{
    using System;

    public interface Ilogger
    {
        void Information(string message);

        void Error(string message, Exception exception);
    }
}

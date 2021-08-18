namespace BasicProject.Services
{
    using BasicProject.Domain;

    using System;

    public interface IHealthService
    {
        ApplicationHealthInfo GetApplicationHealthInfo(string name, Version version);
    }
}

namespace BasicProject.Domain
{
    public class ApplicationHealthInfo
    {
        private ApplicationHealthInfo(string name, string version, HealthStatus status)
        {
            this.Name = name;
            this.Version = version;
            this.Status = status;
        }

        public string Name { get; }

        public string Version { get; }

        public HealthStatus Status { get; }


        public static ApplicationHealthInfo Hydrate(string name, string version)
        {
            var applicationHealthInfo = new ApplicationHealthInfo(name, version, HealthStatus.Up);

            return applicationHealthInfo;
        }
    }
}

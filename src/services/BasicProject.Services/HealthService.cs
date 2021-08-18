namespace BasicProject.Services
{
    using BasicProject.Data;
    using BasicProject.Domain;

    using System;
    using System.Threading.Tasks;

    public class HealthService : IHealthService
    {
        private readonly ICheckSystemDAO checkSystemDAO;

        public HealthService(ICheckSystemDAO checkSystemDAO)
        {
            this.checkSystemDAO = checkSystemDAO;
        }

        public ApplicationHealthInfo GetApplicationHealthInfo(string name, Version version)
        {
            return checkSystemDAO.GetCurrentStatus(name, version.ToString());
        }
    }
}

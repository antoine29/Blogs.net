namespace BasicProject.Data
{
    using BasicProject.Domain;

    public class CheckSystemDAO : ICheckSystemDAO
    {
        public ApplicationHealthInfo GetCurrentStatus(string name, string version)
        {
            return ApplicationHealthInfo.Hydrate(name, version);
        }
    }
}

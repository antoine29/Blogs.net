namespace BasicProject.Data
{
    using BasicProject.Domain;

    public interface ICheckSystemDAO
    {
        ApplicationHealthInfo GetCurrentStatus(string name, string version);
    }
}

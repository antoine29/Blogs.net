namespace BasicProject.Domain
{
    public class Plugin
    {
        public enum PluginTypes
        {
            STAT,
            CHAT,
            EMAIL,
        }

        public PluginTypes Type { get; set; }
    }
}

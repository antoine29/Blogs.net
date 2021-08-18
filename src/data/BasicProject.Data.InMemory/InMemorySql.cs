namespace BasicProject.Data.InMemory
{
    using BasicProject.Data;
    using BasicProject.Logger;

    public class InMemorySql : SqlAbstract
    {
        private readonly Ilogger logger;

        public InMemorySql(Ilogger logger)
        {
            this.logger = logger;
        }

        public override bool Create(object any)
        {
            Sanitize(any);

            logger.Information("Creating from InMemory Database");

            return true;
        }
    }
}

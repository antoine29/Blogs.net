namespace BasicProject.Data.PostgreSql
{
    using BasicProject.Data;
    using BasicProject.Logger;

    public class PostgreSql : SqlAbstract
    {
        private readonly Ilogger logger;

        public PostgreSql(Ilogger logger)
        {
            this.logger = logger;
        }

        public override bool Create(object any)
        {
            Sanitize(any);

            logger.Information("Creating from PostgreSQL Database");
            return true;
        }
    }
}

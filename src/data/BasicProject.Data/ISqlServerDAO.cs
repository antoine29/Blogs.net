namespace BasicProject.Data
{
    using System.Collections.Generic;
    using BasicProject.Domain;

    public interface ISqlServerDAO
    {
        bool Create(object any);

        T FindOne<T>(string filter);

        bool Delete<T>(string id);

        void PopulatePluginsToTemplate(ref Template template);
    }
}

namespace BasicProject.Data
{
    using BasicProject.Domain;

    using System.Collections.Generic;

    public interface ISqlServerDAO
    {
        bool Create(object any);

        T FindOne<T>(string filter);
        
        bool Delete<T>(string id);

        void PopulatePluginsToTemplate(ref Template template);
    }
}

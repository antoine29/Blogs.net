namespace BasicProject.Data.FileStorage
{
    using BasicProject.Domain;
    using System.Collections.Generic;

    public interface StorageMethod
    {
        void Save(object any, string name);
        
        List<Template> FindAllRecords();
    }
}
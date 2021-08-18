namespace BasicProject.Data.FileStorage
{
    using BasicProject.Domain;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using System.IO;

    internal class JSONStorage : StorageMethod
    {
        private string directoryPath;
        private readonly string extensionFile = "json";

        public JSONStorage(string directoryPath)
        {
            this.directoryPath = directoryPath;
        }

        public List<Template> FindAllRecords()
        {
            throw new System.NotImplementedException();
        }

        public void Save(object any, string name)
        {
            var formatter = JsonConvert.SerializeObject(any);
            var filePath = Path.Combine(directoryPath, $"{name}.{extensionFile}");
            var stream = new StreamWriter(filePath);

            stream.Write(formatter);
            stream.Close();
        }
    }
}
namespace BasicProject.Data.FileStorage
{
    using BasicProject.Domain;
    using Microsoft.VisualBasic;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security;

    internal class FileBinaryStorage : StorageMethod
    {
        private readonly string directoryPath;
        private readonly string extensionFile = "dat";

        public FileBinaryStorage(string directoryPath)
        {
            this.directoryPath = directoryPath;
        }

        public List<Template> FindAllRecords()
        {
            var allRecords = new List<Template>();
            var filePaths = Directory.GetFiles(directoryPath, $"*.{extensionFile}");
            var formatter = new BinaryFormatter();

            foreach (var filePath in filePaths)
            {
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var serializedResult = (Template)formatter.Deserialize(stream);

                allRecords.Add(serializedResult);
                stream.Close();
            }

            return allRecords;
        }

        public void Save(object any, string name)
        {
            var formatter = new BinaryFormatter();
            var filePath = Path.Combine(directoryPath, $"{name}.{extensionFile}");
            var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, any);
            stream.Close();
        }
    }
}
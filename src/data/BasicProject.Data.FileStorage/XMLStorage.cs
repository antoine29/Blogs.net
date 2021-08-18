namespace BasicProject.Data.FileStorage
{
    using BasicProject.Domain;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    public class XMLStorage : StorageMethod
    {
        private string directoryPath;
        private readonly string extensionFile = "xml";

        public XMLStorage(string directoryPath)
        {
            this.directoryPath = directoryPath;
        }

        public List<Template> FindAllRecords()
        {
            var allRecords = new List<Template>();
            var filePaths = Directory.GetFiles(directoryPath, $"*.{extensionFile}");
            var formatter = new XmlSerializer(typeof(Template));

            foreach (var filePath in filePaths)
            {
                var stream = new StreamReader(filePath);
                var serializedResult = (Template)formatter.Deserialize(stream);

                allRecords.Add(serializedResult);
                stream.Close();
            }

            return allRecords;
        }

        public void Save(object any, string name)
        {
            var formatter = new XmlSerializer(any.GetType());
            var filePath = Path.Combine(directoryPath, $"{name}.{extensionFile}");
            var stream = new StreamWriter(filePath);

            formatter.Serialize(stream, any);
            stream.Close();
        }
    }
}
namespace BasicProject.Data.FileStorage
{
    public static class FileStorageFactory
    {
        private static string BinaryStorage = "binary";
        private static string XMLStorage = "xml";

        public static StorageMethod GetStorageMethod(string type, string directoryPath)
        {
            StorageMethod storageMethod = null;

            if (type.Equals(BinaryStorage))
            {
                storageMethod = new FileBinaryStorage(directoryPath);
            }

            if (type.Equals(XMLStorage))
            {
                storageMethod = new XMLStorage(directoryPath);
            }

            storageMethod = new JSONStorage(directoryPath);

            return storageMethod;
        }
    }
}

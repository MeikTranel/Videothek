using System;
using System.IO;
using System.Reflection;

namespace Videothek.Persistence
{
    public class PortableLocalDBStorageLocationStrategy : ILocalDBStorageLocationStrategy
    {
        private readonly string _fileName;

        public PortableLocalDBStorageLocationStrategy(string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName));

            _fileName = fileName;
        }


        public string ProvideFilePath() => Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) 
                ?? throw new InvalidOperationException("Could not associate an executing assembly location to determine the database file location."),
            _fileName
        );
    }
}

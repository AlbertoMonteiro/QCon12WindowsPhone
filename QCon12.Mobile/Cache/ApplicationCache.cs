using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using Newtonsoft.Json;
using QCon12.Mobile.Models;

namespace QCon12.Mobile.Cache
{
    public class ApplicationCache
    {
        private readonly IsolatedStorageFile isolatedStorageFile;

        public ApplicationCache()
        {
            isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
        }

        public IEnumerable<Track> Tracks
        {
            get
            {
                const string fileName = "Tracks";
                return GerFromIsolatedStorage<IEnumerable<Track>>(fileName);
            }
            set
            {
                const string fileName = "Tracks";
                SaveInIsolateStorageFile(value, fileName);
            }
        }

        public IEnumerable<Palestra> Palestras
        {
            get
            {
                const string fileName = "Palestras";
                return GerFromIsolatedStorage<IEnumerable<Palestra>>(fileName);
            }
            set
            {
                const string fileName = "Palestras";
                SaveInIsolateStorageFile(value, fileName);
            }
        }

        public IEnumerable<Palestrante> Palestrantes
        {
            get
            {
                const string fileName = "Palestrantes";
                return GerFromIsolatedStorage<IEnumerable<Palestrante>>(fileName);
            }
            set
            {
                const string fileName = "Palestrantes";
                SaveInIsolateStorageFile(value, fileName);
            }
        }

        private T GerFromIsolatedStorage<T>(string fileName)
        {
            if (isolatedStorageFile.FileExists(fileName))
            {
                string json;
                using (var stream = isolatedStorageFile.OpenFile(fileName, FileMode.Open))
                {
                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, (int) stream.Length);
                    json = Encoding.UTF8.GetString(bytes, 0, (int) stream.Length);
                    stream.Close();
                }
                using (var stringReader = new StringReader(json))
                    return new JsonSerializer().Deserialize<T>(new JsonTextReader(stringReader));
            }
            return default(T);
        }

        private void SaveInIsolateStorageFile(object value, string fileName)
        {
            using (var stream = isolatedStorageFile.CreateFile(fileName))
                using (var writer = new StringWriter())
                {
                    using (var jsonTextWriter = new JsonTextWriter(writer))
                        new JsonSerializer().Serialize(jsonTextWriter, value);
                    var s = writer.GetStringBuilder().ToString();
                    var bytes = Encoding.UTF8.GetBytes(s);
                    stream.Write(bytes, 0, bytes.Length);
                }
        }
    }
}

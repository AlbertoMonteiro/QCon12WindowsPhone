using System.Data.Linq;
using QCon12.Mobile.Models;

namespace QCon12.Mobile.Cache
{
    public class CacheContext : DataContext
    {
        public CacheContext(string connectionString = "Data Source=isostore:/CacheDB.sdf")
            : base(connectionString)
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
            }
            DeferredLoadingEnabled = true;
        }

        public Table<Track> Tracks
        {
            get { return GetTable<Track>(); }
        }
        public Table<Palestra> Palestras
        {
            get { return GetTable<Palestra>(); }
        }
        public Table<Palestrante> Palestrantes
        {
            get { return GetTable<Palestrante>(); }
        }
    }
}
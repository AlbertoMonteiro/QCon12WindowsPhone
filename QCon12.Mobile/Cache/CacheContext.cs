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

        public Table<TrackCache> Tracks
        {
            get { return GetTable<TrackCache>(); }
        }
        public Table<PalestraCache> Palestras
        {
            get { return GetTable<PalestraCache>(); }
        }
        public Table<PalestranteCache> Palestrantes
        {
            get { return GetTable<PalestranteCache>(); }
        }
    }
}
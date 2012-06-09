using System.Data.Entity;

namespace QCon12.Models
{
    public class QCon12Context : DbContext
    {
        private static QCon12Context _instance;
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<QCon12.Models.QCon12Context>());

        public QCon12Context()
            : base("name=QCon12Context")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public static QCon12Context Instance
        {
            get
            {
                return _instance ?? (_instance = new QCon12Context());
            }
        }

        public DbSet<Palestrante> Palestrantes { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Palestra> Palestras { get; set; }
    }
}
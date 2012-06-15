using System.Data.Linq;
using System.Data.Linq.Mapping;
using GalaSoft.MvvmLight;

namespace QCon12.Mobile.Models
{
    [Table]
    public class Track : ViewModelBase
    {
        public Track()
        {
            _palestras = new EntitySet<Palestra>(palestra => { palestra.Track = this; },
                                                 palestra => { palestra.Track = null; });
        }

        public Track(string nome, string bio)
            : this()
        {
            Nome = nome;
            Bio = bio;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string Nome { get; set; }
        [Column]
        public string Bio { get; set; }
        [Column]
        public string Logo { get; set; }

        private readonly EntitySet<Palestra> _palestras;

        [Column, Association(Name = "FK_Track_Palestra", Storage = "_palestras", ThisKey = "Id", OtherKey = "TrackId")]
        public EntitySet<Palestra> Palestras { get { return _palestras; } }
    }
}
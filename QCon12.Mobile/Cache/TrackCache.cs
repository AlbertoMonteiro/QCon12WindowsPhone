using System.Data.Linq;
using System.Data.Linq.Mapping;
using QCon12.Mobile.Models;

namespace QCon12.Mobile.Cache
{
    [Table]
    public class TrackCache
    {
        private readonly EntitySet<PalestraCache> _palestras;

        public TrackCache()
        {
            _palestras = new EntitySet<PalestraCache>(palestra => { palestra.Track = this; },
                                                      palestra => { palestra.Track = null; });
        }

        public TrackCache(int id, string nome, string bio, string logo)
            : this()
        {
            Id = id;
            Nome = nome;
            Bio = bio;
            Logo = logo;
        }

        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column]
        public string Nome { get; set; }

        [Column]
        public string Bio { get; set; }

        [Column]
        public string Logo { get; set; }

        [Column, Association(Name = "FK_Track_Palestra", Storage = "_palestras", ThisKey = "Id", OtherKey = "TrackId")]
        public EntitySet<PalestraCache> Palestras
        {
            get { return _palestras; }
        }

        public static implicit operator Track(TrackCache track)
        {
            if (track != null)
                return new Track
                {
                    Id = track.Id,
                    Nome = track.Nome,
                    Bio = track.Bio,
                    Logo = track.Logo
                };
            return null;
        }
    }
}
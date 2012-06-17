using System.Data.Linq.Mapping;
using GalaSoft.MvvmLight;
using QCon12.Mobile.Models;

namespace QCon12.Mobile.Cache
{
    [Table]
    public class PalestranteCache : ViewModelBase
    {
        public PalestranteCache()
        {
            
        }

        public PalestranteCache(int id = 0, string nome = "", string bio = "", string email = "", string foto = "", string twitter = "")
        {
            Id = id;
            Nome = nome;
            Bio = bio;
            Email = email;
            Foto = foto;
            Twitter = twitter;
        }

        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }
        [Column]
        public string Nome { get; set; }
        [Column]
        public string Bio { get; set; }
        [Column]
        public string Twitter { get; set; }
        [Column]
        public string Foto { get; set; }
        [Column]
        public string Email { get; set; }

        public static implicit operator Palestrante(PalestranteCache palestranteCache)
        {
            return new Palestrante
            {
                Id = palestranteCache.Id,
                Nome = palestranteCache.Nome,
                Bio = palestranteCache.Bio,
                Email = palestranteCache.Email,
                Foto = palestranteCache.Foto,
                Twitter = palestranteCache.Twitter
            };
        }
    }
}
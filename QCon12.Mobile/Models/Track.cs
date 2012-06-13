using System.Data.Linq.Mapping;
using GalaSoft.MvvmLight;

namespace QCon12.Mobile.Models
{
    [Table]
    public class Track : ViewModelBase
    {
        public Track() {}

        public Track(string nome, string bio)
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
    }
}
using System.Data.Linq.Mapping;
using GalaSoft.MvvmLight;

namespace QCon12.Mobile.Models
{
    [Table]
    public class Palestrante : ViewModelBase
    {
        public Palestrante() {}

        public Palestrante(string nome, string foto)
        {
            Nome = nome;
            Foto = foto;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
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
    }
}
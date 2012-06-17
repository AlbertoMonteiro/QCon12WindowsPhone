using GalaSoft.MvvmLight;

namespace QCon12.Mobile.Models
{
    public class Palestrante : ViewModelBase
    {
        public Palestrante() {}

        public Palestrante(string nome, string foto)
        {
            Nome = nome;
            Foto = foto;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Bio { get; set; }
        public string Twitter { get; set; }
        public string Foto { get; set; }
        public string Email { get; set; }
    }
}
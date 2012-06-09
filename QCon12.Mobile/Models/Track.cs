using System.ComponentModel;

namespace QCon12.Mobile.Models
{
    public class Track : INotifyPropertyChanged
    {
        public Track() {}

        public Track(string nome, string bio)
        {
            Nome = nome;
            Bio = bio;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Bio { get; set; }
        public string Logo { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
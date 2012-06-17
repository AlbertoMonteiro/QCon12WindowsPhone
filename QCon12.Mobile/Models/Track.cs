using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace QCon12.Mobile.Models
{
    public class Track : ViewModelBase
    {
        public Track() {}

        public Track(string nome, string bio)
            : this()
        {
            Nome = nome;
            Bio = bio;
        }

        public int Id { get; set; }

        public string Nome { get; set; }
        public string Bio { get; set; }
        public string Logo { get; set; }
        public ObservableCollection<Palestra> Palestras { get; set; }
    }
}
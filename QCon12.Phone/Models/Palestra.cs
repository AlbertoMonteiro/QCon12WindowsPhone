using System;
using System.ComponentModel;

namespace QCon12.Phone.Models
{
    public class Palestra : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Track Track { get; set; }
        public DateTime Horario { get; set; }
        public Palestrante Palestrante { get; set; }
        public string Descricao { get; set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
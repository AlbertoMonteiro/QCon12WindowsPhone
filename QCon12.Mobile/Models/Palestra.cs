using System;
using GalaSoft.MvvmLight;

namespace QCon12.Mobile.Models
{
    public class Palestra : ViewModelBase
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime Horario { get; set; }

        public string Descricao { get; set; }

        public int TrackId { get; set; }

        public Track Track { get; set; }

        public Palestrante Palestrante { get; set; }
    }
}
using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;

namespace QCon12.Mobile.Models
{
    [Table]
    public class Palestra : INotifyPropertyChanged
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string Nome { get; set; }
        [Column,Association]
        public Track Track { get; set; }
        [Column]
        public DateTime Horario { get; set; }
        [Column, Association]
        public Palestrante Palestrante { get; set; }
        [Column]
        public string Descricao { get; set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
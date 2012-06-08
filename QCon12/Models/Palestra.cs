using System;

namespace QCon12.Models
{
    public class Palestra
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Track Track { get; set; }
        public DateTime Horario { get; set; }
        public Palestrante Palestrante { get; set; }
        public string Descricao { get; set; }
    }
}
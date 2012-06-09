using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QCon12.Models
{
    public class Palestra
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TrackId { get; set; }
        [ForeignKey("TrackId")]
        public Track Track { get; set; }
        public DateTime Horario { get; set; }
        public int PalestranteId { get; set; }
        [ForeignKey("PalestranteId")]
        public Palestrante Palestrante { get; set; }
        public string Descricao { get; set; }
    }
}
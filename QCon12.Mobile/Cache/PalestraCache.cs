using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using GalaSoft.MvvmLight;
using QCon12.Mobile.Models;

namespace QCon12.Mobile.Cache
{
    [Table]
    public class PalestraCache : ViewModelBase
    {
        private EntityRef<TrackCache> _track;

        public PalestraCache() {}

        public PalestraCache(int id, string nome, string descricao, DateTime horario)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Horario = horario;
        }

        //private EntityRef<Palestrante> _palestrante;

        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column]
        public string Nome { get; set; }

        [Column]
        public DateTime Horario { get; set; }

        [Column]
        public string Descricao { get; set; }

        [Column(DbType = "Int")]
        public int? TrackId { get; set; }

        [Column, Association(Name = "FK_Track_Palestra", Storage = "_track", ThisKey = "TrackId", OtherKey = "Id", IsForeignKey = true)]
        public TrackCache Track
        {
            get { return _track.Entity; }
            set
            {
                var prevTrack = _track.Entity;
                if (prevTrack != value || _track.HasLoadedOrAssignedValue == false)
                {
                    _track.Entity = prevTrack != null ? null : value;
                    TrackId = value != null ? value.Id : default(int?);
                }
            }
        }

        /*[Column(DbType = "Int")]
        public int? PalestranteId { get; set; }

        [Column, Association(Name = "FK_Palestrante_Palestra", Storage = "_palestrante", ThisKey = "Id", IsForeignKey = true)]
        public Palestrante Palestrante
        {
            get { return _palestrante.Entity; }
            set
            {
                var prevePalestrante = _palestrante.Entity;
                if (prevePalestrante != value || _palestrante.HasLoadedOrAssignedValue == false)
                {
                    if (prevePalestrante != null)
                        _palestrante.Entity = null;
                    _palestrante.Entity = value;
                    PalestranteId = value != null ? value.Id : default(int?);
                }
            } 
        }*/

        public static implicit operator Palestra(PalestraCache palestra)
        {
            return new Palestra
            {
                Id = palestra.Id,
                Nome = palestra.Nome,
                Descricao = palestra.Descricao,
                Horario = palestra.Horario,
                Track = palestra.Track
            };
        }
    }
}
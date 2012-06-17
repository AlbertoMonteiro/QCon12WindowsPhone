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
        private EntityRef<PalestranteCache> _palestrante;
        private EntityRef<TrackCache> _track;

        public PalestraCache() { }

        public PalestraCache(int id, string nome, string descricao, DateTime horario)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Horario = horario;
        }

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

        [Column(DbType = "Int")]
        public int? PalestranteId { get; set; }

        [Column, Association(Name = "FK_Track_Palestrante", Storage = "_palestrante", ThisKey = "PalestranteId", OtherKey = "Id", IsForeignKey = true)]
        public PalestranteCache Palestrante
        {
            get { return _palestrante.Entity; }
            set
            {
                var prevTrack = _palestrante.Entity;
                if (prevTrack != value || _palestrante.HasLoadedOrAssignedValue == false)
                {
                    _palestrante.Entity = prevTrack != null ? null : value;
                    PalestranteId = value != null ? value.Id : default(int?);
                }
            }
        }

        public static implicit operator Palestra(PalestraCache palestraCache)
        {
            var palestra = new Palestra
            {
                Id = palestraCache.Id,
                Nome = palestraCache.Nome,
                Descricao = palestraCache.Descricao,
                Horario = palestraCache.Horario,
                Track = palestraCache.Track
            };
            if (palestraCache.Palestrante != null)
                palestra.Palestrante = palestraCache.Palestrante;
            if (palestraCache.Track != null) 
                palestra.Track = palestraCache.Track;
            return palestra;
        }
    }
}
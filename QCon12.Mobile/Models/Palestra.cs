using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using GalaSoft.MvvmLight;

namespace QCon12.Mobile.Models
{
    [Table]
    public class Palestra : ViewModelBase
    {
        private EntityRef<Track> _track;
        //private EntityRef<Palestrante> _palestrante;

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
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
        public Track Track
        {
            get { return _track.Entity; }
            set
            {
                var prevTrack = _track.Entity;
                if (prevTrack != value || _track.HasLoadedOrAssignedValue == false)
                {
                    if (prevTrack != null)
                    {
                        _track.Entity = null;
                        prevTrack.Palestras.Remove(this);
                    }
                    _track.Entity = value;
                    if (value != null)
                    {
                        value.Palestras.Add(this);
                        TrackId = value.Id;
                    } else
                        TrackId = default(int?);
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
    }
}
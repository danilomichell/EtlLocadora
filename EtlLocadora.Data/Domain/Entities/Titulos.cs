using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities
{
    public partial class Titulos
    {
        public Titulos()
        {
            Copias = new HashSet<Copias>();
        }

        public int CodTit { get; set; }
        public string TpoTit { get; set; } = null!;
        public string ClaTit { get; set; } = null!;
        public byte QtdCop { get; set; }
        public DateTime DatLanc { get; set; }
        public byte CodArt { get; set; }
        public byte CodGrav { get; set; }
        public string DscTit { get; set; } = null!;

        public virtual Artistas CodArtNavigation { get; set; } = null!;
        public virtual Gravadoras CodGravNavigation { get; set; } = null!;
        public virtual ICollection<Copias> Copias { get; set; }
    }
}

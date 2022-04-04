using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities.Relacional
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
        public int QtdCop { get; set; }
        public DateTime DatLanc { get; set; }
        public int CodArt { get; set; }
        public int CodGrav { get; set; }
        public string DscTit { get; set; } = null!;

        public virtual Artistas CodArtNavigation { get; set; } = null!;
        public virtual Gravadoras CodGravNavigation { get; set; } = null!;
        public virtual ICollection<Copias> Copias { get; set; }
    }
}

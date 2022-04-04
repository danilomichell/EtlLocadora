using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities.Relacional
{
    public partial class Artistas
    {
        public Artistas()
        {
            Titulos = new HashSet<Titulos>();
        }

        public int CodArt { get; set; }
        public string TpoArt { get; set; } = null!;
        public string NacBras { get; set; } = null!;
        public int CodGrav { get; set; }
        public int QtdTit { get; set; }
        public decimal MedAnual { get; set; }
        public string NomArt { get; set; } = null!;

        public virtual Gravadoras CodGravNavigation { get; set; } = null!;
        public virtual ICollection<Titulos> Titulos { get; set; }
    }
}

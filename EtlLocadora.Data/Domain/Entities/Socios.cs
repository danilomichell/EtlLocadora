using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities
{
    public partial class Socios
    {
        public Socios()
        {
            Locacoes = new HashSet<Locacoes>();
        }

        public byte CodSoc { get; set; }
        public DateTime DatCad { get; set; }
        public byte CodTps { get; set; }
        public string StaSoc { get; set; } = null!;
        public string NomSoc { get; set; } = null!;

        public virtual TiposSocios CodTpsNavigation { get; set; } = null!;
        public virtual ICollection<Locacoes> Locacoes { get; set; }
    }
}

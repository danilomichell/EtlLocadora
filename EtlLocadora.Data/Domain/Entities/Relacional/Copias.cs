using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities.Relacional
{
    public partial class Copias
    {
        public Copias()
        {
            ItensLocacoes = new HashSet<ItensLocacoes>();
        }

        public int CodTit { get; set; }
        public byte NumCop { get; set; }
        public DateTime DatAq { get; set; }
        public string Status { get; set; } = null!;

        public virtual Titulos CodTitNavigation { get; set; } = null!;
        public virtual ICollection<ItensLocacoes> ItensLocacoes { get; set; }
    }
}

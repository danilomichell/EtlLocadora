using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities
{
    public partial class ItensLocacoes
    {
        public byte CodSoc { get; set; }
        public DateTime DatLoc { get; set; }
        public int CodTit { get; set; }
        public byte NumCop { get; set; }
        public DateTime DatPrev { get; set; }
        public decimal ValLoc { get; set; }
        public string StaMul { get; set; } = null!;
        public DateTime? DatDev { get; set; }

        public virtual Copias Copias { get; set; } = null!;
        public virtual Locacoes Locacoes { get; set; } = null!;
    }
}

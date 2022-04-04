using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities.Relacional
{
    public partial class ItensLocacoes
    {
        public int CodSoc { get; set; }
        public DateTime DatLoc { get; set; }
        public int CodTit { get; set; }
        public int NumCop { get; set; }
        public DateTime DatPrev { get; set; }
        public decimal ValLoc { get; set; }
        public string StaMul { get; set; } = null!;
        public DateTime? DatDev { get; set; }

        public virtual Copias Copias { get; set; } = null!;
        public virtual Locacoes Locacoes { get; set; } = null!;
    }
}

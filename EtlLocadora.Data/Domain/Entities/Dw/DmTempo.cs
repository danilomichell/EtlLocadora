using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities.Dw
{
    public partial class DmTempo
    {
        public DmTempo()
        {
            FtLocacoes = new HashSet<FtLocacoes>();
        }

        public int IdTempo { get; set; }
        public int NuAno { get; set; }
        public int NuMes { get; set; }
        public int NuAnomes { get; set; }
        public string SgMes { get; set; } = null!;
        public string NmMesano { get; set; } = null!;
        public string NmMes { get; set; } = null!;
        public int NuDia { get; set; }
        public DateTime DtTempo { get; set; }
        public int NuHora { get; set; }
        public string Turno { get; set; } = null!;

        public virtual ICollection<FtLocacoes> FtLocacoes { get; set; }
    }
}

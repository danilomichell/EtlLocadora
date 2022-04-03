using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities
{
    public partial class DmTempo
    {
        public DmTempo()
        {
            FtLocacoes = new HashSet<FtLocacoes>();
        }

        public int IdTempo { get; set; }
        public byte NuAno { get; set; }
        public byte NuMes { get; set; }
        public int NuAnomes { get; set; }
        public string SgMes { get; set; } = null!;
        public string NmMesano { get; set; } = null!;
        public string NmMes { get; set; } = null!;
        public byte NuDia { get; set; }
        public DateTime DtTempo { get; set; }
        public byte NuHora { get; set; }
        public string Turno { get; set; } = null!;

        public virtual ICollection<FtLocacoes> FtLocacoes { get; set; }
    }
}

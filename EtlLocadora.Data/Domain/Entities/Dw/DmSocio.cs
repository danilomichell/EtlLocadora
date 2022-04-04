using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities.Dw
{
    public partial class DmSocio
    {
        public DmSocio()
        {
            FtLocacoes = new HashSet<FtLocacoes>();
        }

        public int IdSoc { get; set; }
        public string NomSoc { get; set; } = null!;
        public string TipoSocio { get; set; } = null!;

        public virtual ICollection<FtLocacoes> FtLocacoes { get; set; }
    }
}

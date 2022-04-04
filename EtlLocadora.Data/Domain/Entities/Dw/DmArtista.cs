using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities.Dw
{
    public partial class DmArtista
    {
        public DmArtista()
        {
            FtLocacoes = new HashSet<FtLocacoes>();
        }

        public byte IdArt { get; set; }
        public string TpoArt { get; set; } = null!;
        public string NacBras { get; set; } = null!;
        public string NomArt { get; set; } = null!;

        public virtual ICollection<FtLocacoes> FtLocacoes { get; set; }
    }
}

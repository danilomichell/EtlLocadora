using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities
{
    public partial class DmGravadora
    {
        public DmGravadora()
        {
            FtLocacoes = new HashSet<FtLocacoes>();
        }

        public byte IdGrav { get; set; }
        public string UfGrav { get; set; } = null!;
        public string NacBras { get; set; } = null!;
        public string NomGrav { get; set; } = null!;

        public virtual ICollection<FtLocacoes> FtLocacoes { get; set; }
    }
}

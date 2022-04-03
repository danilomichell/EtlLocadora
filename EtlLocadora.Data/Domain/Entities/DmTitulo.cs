using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities
{
    public partial class DmTitulo
    {
        public DmTitulo()
        {
            FtLocacoes = new HashSet<FtLocacoes>();
        }

        public int IdTitulo { get; set; }
        public string TpoTitulo { get; set; } = null!;
        public string ClaTitulo { get; set; } = null!;
        public string DscTitulo { get; set; } = null!;

        public virtual ICollection<FtLocacoes> FtLocacoes { get; set; }
    }
}

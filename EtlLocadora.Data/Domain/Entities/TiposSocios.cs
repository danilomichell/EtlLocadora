using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities
{
    public partial class TiposSocios
    {
        public TiposSocios()
        {
            Socios = new HashSet<Socios>();
        }

        public byte CodTps { get; set; }
        public byte LimTit { get; set; }
        public decimal ValBase { get; set; }
        public string DscTps { get; set; } = null!;

        public virtual ICollection<Socios> Socios { get; set; }
    }
}

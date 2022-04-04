using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities.Relacional
{
    public partial class Locacoes
    {
        public Locacoes()
        {
            ItensLocacoes = new HashSet<ItensLocacoes>();
        }

        public int CodSoc { get; set; }
        public DateTime DatLoc { get; set; }
        public decimal ValLoc { get; set; }
        public DateTime DatVenc { get; set; }
        public string StaPgto { get; set; } = null!;
        public DateTime? DatPgto { get; set; }

        public virtual Socios CodSocNavigation { get; set; } = null!;
        public virtual ICollection<ItensLocacoes> ItensLocacoes { get; set; }
    }
}

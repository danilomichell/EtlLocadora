using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities.Dw
{
    public partial class FtLocacoes
    {
        public int IdSoc { get; set; }
        public int IdTitulo { get; set; }
        public int IdArt { get; set; }
        public int IdGrav { get; set; }
        public int IdTempo { get; set; }
        public decimal ValorArrecadado { get; set; }
        public decimal TempoDevolucao { get; set; }
        public decimal MultaAtraso { get; set; }

        public virtual DmArtista IdArtNavigation { get; set; } = null!;
        public virtual DmGravadora IdGravNavigation { get; set; } = null!;
        public virtual DmSocio IdSocNavigation { get; set; } = null!;
        public virtual DmTempo IdTempoNavigation { get; set; } = null!;
        public virtual DmTitulo IdTituloNavigation { get; set; } = null!;
    }
}

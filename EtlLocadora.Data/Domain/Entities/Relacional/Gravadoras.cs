using System;
using System.Collections.Generic;

namespace EtlLocadora.Data.Domain.Entities.Relacional
{
    public partial class Gravadoras
    {
        public Gravadoras()
        {
            Artistas = new HashSet<Artistas>();
            Titulos = new HashSet<Titulos>();
        }

        public byte CodGrav { get; set; }
        public string UfGrav { get; set; } = null!;
        public string NacBras { get; set; } = null!;
        public string NomGrav { get; set; } = null!;

        public virtual ICollection<Artistas> Artistas { get; set; }
        public virtual ICollection<Titulos> Titulos { get; set; }
    }
}

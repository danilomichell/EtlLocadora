using System.Data;
using System.Data.Common;
using System.Diagnostics;
using EtlLocadora.Data.Context;
using EtlLocadora.Data.Domain.Entities.Relacional;
using Microsoft.EntityFrameworkCore;

namespace EtlLocadora.Processamento.Etl
{
    public class Extract
    {

        public List<DateTime> Tempo { get; private set; } = new();
        public List<Socios> Socios { get; private set; } = new();
        public List<Titulos> Titulos { get; private set; } = new();
        public List<Artistas> Artistas { get; private set; } = new();
        public List<Gravadoras> Gravadoras { get; private set; } = new();
        public List<Locacoes> Locacoes { get; private set; } = new();
        public Extract(LocadoraContext context)
        {
            ExtrairTempo(context);
            ExtrairSocios(context);
            ExtrairTitulos(context);
            ExtrairArtistas(context);
            ExtrairGravadora(context);
            ExtrairLocacoes(context);
        }

        private void ExtrairTempo(LocadoraContext context)
        {
            Console.WriteLine("Iniciando extração do Tempo");
            var sw = new Stopwatch();
            sw.Start();
            Tempo = context.Locacoes.Select(x => x.DatLoc).Distinct().ToList();
            sw.Stop();

            Console.WriteLine($"Finalizando extração do Tempo" +
                              $" - Total extraido: {Tempo.Count}" +
                              $" - Tempo de extração: {sw.Elapsed.TotalSeconds} segundos.");

        }

        private void ExtrairSocios(LocadoraContext context)
        {
            Console.WriteLine("Iniciando extração dos Socios");
            var sw = new Stopwatch();
            sw.Start();

            Socios = context.Socios.Include(x => x.CodTpsNavigation).Distinct().ToList();

            sw.Stop();
            Console.WriteLine($"Finalizando extração dos Socios" +
                              $" - Total extraido: {Socios.Count}" +
                              $" - Tempo de extração: {sw.Elapsed.TotalSeconds} segundos.");
        }

        private void ExtrairTitulos(LocadoraContext context)
        {
            Console.WriteLine("Iniciando extração dos Titulos");
            var sw = new Stopwatch();
            sw.Start();

            Titulos = context.Titulos.Distinct().ToList();
            sw.Stop();
            Console.WriteLine($"Finalizando extração dos Titulos" +
                                          $" - Total extraido: {Titulos.Count}" +
                                          $" - Tempo de extração: {sw.Elapsed.TotalSeconds} segundos.");
        }

        private void ExtrairArtistas(LocadoraContext context)
        {
            Console.WriteLine("Iniciando extração dos Artitas");
            var sw = new Stopwatch();
            sw.Start();

            Artistas = context.Artistas.Distinct().ToList();

            sw.Stop();
            Console.WriteLine($"Finalizando extração dos Artistas" +
                              $" - Total extraido: {Artistas.Count}" +
                              $" - Tempo de extração: {sw.Elapsed.TotalSeconds} segundos.");
        }

        private void ExtrairGravadora(LocadoraContext context)
        {
            Console.WriteLine("Iniciando extração das Gravadora");
            var sw = new Stopwatch();
            sw.Start();

            Gravadoras = context.Gravadoras.Distinct().ToList();

            sw.Stop();
            Console.WriteLine($"Finalizando extração das Gravadora" +
                             $" - Total extraido: {Gravadoras.Count}" +
                             $" - Tempo de extração: {sw.Elapsed.TotalSeconds} segundos.");
        }

        private void ExtrairLocacoes(LocadoraContext context)
        {
            Console.WriteLine("Iniciando extração das Locações");
            var sw = new Stopwatch();
            sw.Start();

            Locacoes = context.Locacoes.Include(x => x.ItensLocacoes)
                                       .ThenInclude(x => x.Copias)
                                       .ThenInclude(x => x.CodTitNavigation)
                                       .ThenInclude(x => x.CodArtNavigation)
                                       .ToList();

            sw.Stop();
            Console.WriteLine($"Finalizando extração das Locações" +
                                          $" - Total extraido: {Locacoes.Count}" +
                                          $" - Tempo de extração: {sw.Elapsed.TotalSeconds} segundos.");
        }
    }
}

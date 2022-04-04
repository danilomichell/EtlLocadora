using EtlLocadora.Data.Domain.Entities.Dw;
using EtlLocadora.Data.Domain.Entities.Relacional;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtlLocadora.Processamento.Etl
{
    public class Transform
    {
        public List<DmTempo> DmTempo { get; private set; } = new();
        public List<DmSocio> DmSocios { get; private set; } = new();
        public List<DmTitulo> DmTitulos { get; private set; } = new();
        public List<DmArtista> DmArtistas { get; private set; } = new();
        public List<DmGravadora> DmGravadoras { get; private set; } = new();
        public List<FtLocacoes> FtLocacoes { get; private set; } = new();

        public Transform(Extract extracao)
        {
            TransformarTempo(extracao.Tempo);
            TransformarSocios(extracao.Socios);
            TransformarTitulos(extracao.Titulos);
            TransformarArtistas(extracao.Artistas);
            TransformarGravadoras(extracao.Gravadoras);
            //TransformarFtLocacoes(extracao.Locacoes);
        }

        private void TransformarTempo(List<DateTime> tempo)
        {
            Console.WriteLine("Iniciando transformação do tempo");
            var sw = new Stopwatch();
            sw.Start();
            foreach (var item in tempo)
            {
                DmTempo.Add(new DmTempo
                {
                    DtTempo = item,
                    NmMes = item.Month.ToString(),
                    NuHora = item.Hour,
                    NmMesano = item.Month.ToString() + "/" + item.Year.ToString(),
                    NuAno = item.Year,
                    NuDia = item.Day,
                    NuAnomes = item.Year * 100 + item.Month,
                    NuMes = item.Month
                });
            }
            sw.Stop();

            Console.WriteLine($"Finalizando transformação do tempo" +
                              $" - Tempo de transformação: {sw.Elapsed.TotalSeconds} segundos.");

        }
        private void TransformarSocios(List<Socios> socios)
        {
            Console.WriteLine("Iniciando transformação dos Socios");
            var sw = new Stopwatch();
            sw.Start();
            foreach (var item in socios)
            {
                DmSocios.Add(new DmSocio
                {
                    IdSoc = item.CodSoc,
                    NomSoc = item.NomSoc,
                    TipoSocio = item.StaSoc
                });
            }
            sw.Stop();

            Console.WriteLine($"Finalizando transformação dos Socios" +
                              $" - Tempo de transformação: {sw.Elapsed.TotalSeconds} segundos.");
        }
        private void TransformarTitulos(List<Titulos> titulos)
        {
            Console.WriteLine("Iniciando transformação dos Titulos");
            var sw = new Stopwatch();
            sw.Start();
            foreach (var item in titulos)
            {
                DmTitulos.Add(new DmTitulo
                {
                    IdTitulo = item.CodTit,
                    TpoTitulo = item.TpoTit,
                    DscTitulo = item.DscTit,
                    ClaTitulo = item.ClaTit
                });
            }
            sw.Stop();

            Console.WriteLine($"Finalizando transformação dos Titulos" +
                              $" - Tempo de transformação: {sw.Elapsed.TotalSeconds} segundos.");
        }
        private void TransformarArtistas(List<Artistas> artistas)
        {
            Console.WriteLine("Iniciando transformação dos Artistas");
            var sw = new Stopwatch();
            sw.Start();
            foreach (var item in artistas)
            {
                DmArtistas.Add(new DmArtista
                {
                    IdArt = item.CodArt,
                    NacBras = item.NacBras,
                    NomArt = item.NomArt,
                    TpoArt = item.TpoArt
                });
            }
            sw.Stop();

            Console.WriteLine($"Finalizando transformação dos Artistas" +
                              $" - Tempo de transformação: {sw.Elapsed.TotalSeconds} segundos.");
        }
        private void TransformarGravadoras(List<Gravadoras> gravadoras)
        {
            Console.WriteLine("Iniciando transformação das Gravadoras");
            var sw = new Stopwatch();
            sw.Start();
            foreach (var item in gravadoras)
            {
                DmGravadoras.Add(new DmGravadora
                {
                    IdGrav = item.CodGrav,
                    NomGrav = item.NomGrav,
                    UfGrav = item.UfGrav
                });
            }
            sw.Stop();

            Console.WriteLine($"Finalizando transformação das Gravadoras" +
                              $" - Tempo de transformação: {sw.Elapsed.TotalSeconds} segundos.");
        }

        //private void TransformarFtLocacoes(DataTable data)
        //{
        //    Console.WriteLine("Iniciando transformação das Locações");
        //    var sw = new Stopwatch();
        //    sw.Start();
        //    var locacoes = new List<Locacoes>();

        //    foreach (DataRow item in data.Rows)
        //    {
        //        var obj = item.ItemArray;
        //        DateTime? dtPamento = obj[6] is DBNull ? null : Convert.ToDateTime(obj[6]);
        //        locacoes.Add(new Locacoa
        //        {
        //            IdSoc = Convert.ToInt32(obj[0]),
        //            IdGravadora = Convert.ToInt32(obj[1]),
        //            IdTitulo = Convert.ToInt32(obj[2]),
        //            IdArtista = Convert.ToInt32(obj[3]),
        //            DataLocacao = Convert.ToDateTime(obj[4]),
        //            ValorLocacao = Convert.ToDecimal(obj[5]),
        //            DataPagamento = dtPamento,
        //            DataVencimento = Convert.ToDateTime(obj[7]),
        //            StPagamento = obj[8] is "P" ? true : false
        //        });
        //    }

        //    FtLocacoes = locacoes.GroupBy(x => new {
        //        x.IdArtista,
        //        x.IdGravadora,
        //        x.IdSocio,
        //        x.IdTitulo,
        //        x.DataLocacao
        //    }
        //                                )
        //                         .Select(x => new FtLocacao(x.Key.IdGravadora,
        //                                                   x.Key.IdArtista,
        //                                                   x.Key.IdSocio,
        //                                                   Convert.ToInt64(x.Key.DataLocacao.ToString("yyyyMMdd")),
        //                                                   x.Key.IdTitulo,
        //                                                   x.ToList()
        //                                ))
        //                         .ToList();

        //    sw.Stop();

        //    Console.WriteLine($"Finalizando transformação das Locações" +
        //                      $" - Tempo de transformação: {sw.Elapsed.TotalSeconds} segundos.");
        //}
    }
}

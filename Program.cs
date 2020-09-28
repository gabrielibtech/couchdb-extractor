using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace couchdb_extractor
{
    public static class Extensions
    {

        public static String ToStringJ(this JToken j)
        {
            if (j == null)
            {
                return "";
            }
            return j.ToString();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<String> jaImportado = new List<String>(); //(new String[] { "klyibtech_teste_rep00217_pedido", "klyibtech_pedidos_rep00049_pedido", "klyibtech_teste_rep00417_pedido", "klyibtech_pedidos_rep00447_pedido", "klyibtech_pedidos_rep00385_pedido", "klyibtech_teste_rep00231_pedido", "klyibtech_teste_rep00418_pedido", "klyibtech_pedidos_rep00102_pedido", "klyibtech_teste_rep00246_pedido", "klyibtech_teste_rep00419_pedido", "klyibtech_teste_rep00421_pedido", "klyibtech_teste_rep00250_pedido", "klyibtech_teste_rep00251_pedido", "klyibtech_teste_rep00253_pedido", "klyibtech_teste_rep00424_pedido", "klyibtech_teste_rep00425_pedido", "klyibtech_teste_rep00262_pedido", "klyibtech_teste_rep00426_pedido", "klyibtech_teste_rep00264_pedido", "klyibtech_teste_rep00267_pedido", "klyibtech_teste_rep00272_pedido", "klyibtech_teste_rep00427_pedido", "klyibtech_teste_rep00273_pedido", "klyibtech_teste_rep00428_pedido", "klyibtech_teste_rep00282_pedido", "klyibtech_teste_rep00432_pedido", "klyibtech_teste_rep00433_pedido", "klyibtech_teste_rep00283_pedido", "klyibtech_teste_rep00434_pedido", "klyibtech_teste_rep00286_pedido", "klyibtech_teste_rep00435_pedido", "klyibtech_teste_rep00436_pedido", "klyibtech_teste_rep00290_pedido", "klyibtech_teste_rep00437_pedido", "klyibtech_teste_rep00298_pedido", "klyibtech_teste_rep00308_pedido", "klyibtech_teste_rep00311_pedido", "klyibtech_teste_rep00438_pedido", "klyibtech_teste_rep00439_pedido", "klyibtech_teste_rep00337_pedido", "klyibtech_teste_rep00440_pedido", "klyibtech_teste_rep00441_pedido", "klyibtech_teste_rep00442_pedido", "klyibtech_teste_rep00443_pedido", "klyibtech_teste_rep00345_pedido", "klyibtech_teste_rep00347_pedido", "klyibtech_teste_rep00444_pedido", "klyibtech_teste_rep00445_pedido", "klyibtech_teste_rep00353_pedido", "klyibtech_pedidos_rep00104_pedido", "klyibtech_teste_rep00446_pedido", "klyibtech_teste_rep00366_pedido", "klyibtech_teste_rep00447_pedido", "klyibtech_teste_rep00369_pedido", "klyibtech_teste_rep00448_pedido", "klyibtech_teste_rep00375_pedido", "klyibtech_teste_rep00449_pedido", "klyibtech_teste_rep00377_pedido", "klyibtech_pedidos_rep00448_pedido", "klyibtech_teste_rep00450_pedido", "klyibtech_teste_rep00385_pedido", "klyibtech_teste_rep00388_pedido", "klyibtech_teste_rep00389_pedido", "klyibtech_teste_rep00469_pedido", "klyibtech_teste_rep00390_pedido", "klyibtech_teste_rep00393_pedido", "klyibtech_teste_rep00394_pedido", "klyibtech_teste_rep00470_pedido", "klyibtech_teste_rep00471_pedido", "klyibtech_teste_rep00397_pedido", "klyibtech_teste_rep00399_pedido", "klyibtech_teste_rep00472_pedido", "klyibtech_teste_rep00403_pedido", "klyibtech_teste_rep00404_pedido", "klyibtech_teste_rep00476_pedido", "klyibtech_teste_rep00405_pedido", "klyibtech_teste_rep00477_pedido", "klyibtech_teste_rep00406_pedido", "klyibtech_teste_rep00478_pedido", "klyibtech_teste_rep00481_pedido", "klyibtech_teste_rep00409_pedido", "klyibtech_teste_rep00483_pedido", "klyibtech_teste_rep00484_pedido", "klyibtech_teste_rep00411_pedido", "klyibtech_teste_rep00412_pedido", "klyibtech_teste_rep00485_pedido", "klyibtech_teste_rep00413_pedido", "klyibtech_teste_rep00486_pedido", "klyibtech_teste_rep00414_pedido", "klyibtech_teste_rep00490_pedido", "klyibtech_teste_rep00415_pedido", "klyibtech_teste_rep00491_pedido", "klyibtech_teste_rep00416_pedido", "klyibtech_teste_rep00492_pedido", "klyibtech_teste_rep207_pedido", "klyibtech_teste_rep062754_pedid", "klyibtech_teste_rep203_pedido", "klyibtech_pedidos_rep00113_pedido", "klyibtech_pedidos_rep00231_pedido", "klyibtech_pedidos_rep00388_pedido", "klyibtech_pedidos_rep00311_pedido", "klyibtech_pedidos_rep00449_pedido", "klyibtech_pedidos_rep00450_pedido", "klyibtech_pedidos_rep00389_pedido", "klyibtech_pedidos_rep00469_pedido", "klyibtech_pedidos_rep00118_pedido", "klyibtech_pedidos_rep00337_pedido", "klyibtech_pedidos_rep00470_pedido", "klyibtech_pedidos_rep00246_pedido", "klyibtech_pedidos_rep00119_pedido", "klyibtech_pedidos_rep00390_pedido", "klyibtech_pedidos_rep00471_pedido", "klyibtech_pedidos_rep00345_pedido", "klyibtech_pedidos_rep00128_pedido", "klyibtech_pedidos_rep00393_pedido", "klyibtech_pedidos_rep00250_pedido", "klyibtech_pedidos_rep00347_pedido", "klyibtech_pedidos_rep00394_pedido", "klyibtech_pedidos_rep00397_pedido", "klyibtech_pedidos_rep00472_pedido", "klyibtech_pedidos_rep00476_pedido", "klyibtech_pedidos_rep00251_pedido", "klyibtech_pedidos_rep00477_pedido", "klyibtech_pedidos_rep00399_pedido", "klyibtech_pedidos_rep00134_pedido", "klyibtech_pedidos_rep00478_pedido", "klyibtech_pedidos_rep00353_pedido", "klyibtech_pedidos_rep00136_pedido", "klyibtech_pedidos_rep00401_pedido", "klyibtech_pedidos_rep00403_pedido", "klyibtech_pedidos_rep00253_pedido", "klyibtech_pedidos_rep00366_pedido", "klyibtech_pedidos_rep00481_pedido", "klyibtech_pedidos_rep00404_pedido", "klyibtech_pedidos_rep00405_pedido", "klyibtech_pedidos_rep00262_pedido", "klyibtech_pedidos_rep00483_pedido", "klyibtech_pedidos_rep00369_pedido", "klyibtech_pedidos_rep00169_pedido", "klyibtech_pedidos_rep00264_pedido", "klyibtech_pedidos_rep00484_pedido", "klyibtech_pedidos_rep00485_pedido", "klyibtech_pedidos_rep00170_pedido", "klyibtech_pedidos_rep00267_pedido", "klyibtech_pedidos_rep00375_pedido", "klyibtech_pedidos_rep00406_pedido", "klyibtech_pedidos_rep00173_pedido", "klyibtech_pedidos_rep00486_pedido", "klyibtech_pedidos_rep00490_pedido", "klyibtech_pedidos_rep00377_pedido", "klyibtech_pedidos_rep00409_pedido", "klyibtech_pedidos_rep00491_pedido", "klyibtech_pedidos_rep00180_pedido", "klyibtech_pedidos_rep00378_pedido", "klyibtech_pedidos_rep00412_pedido", "klyibtech_pedidos_rep00492_pedido", "klyibtech_pedidos_rep00272_pedido", "klyibtech_pedidos_rep00493_pedido", "klyibtech_pedidos_rep00411_pedido", "klyibtech_pedidos_rep00202_pedido", "klyibtech_pedidos_rep00413_pedido", "klyibtech_pedidos_rep00495_pedido", "klyibtech_pedidos_rep00433_pedido", "klyibtech_pedidos_rep00496_pedido", "klyibtech_pedidos_rep00414_pedido", "klyibtech_pedidos_rep00497_pedido", "klyibtech_pedidos_rep00434_pedido", "klyibtech_pedidos_rep00415_pedido", "klyibtech_pedidos_rep00498_pedido", "klyibtech_pedidos_rep00273_pedido", "klyibtech_pedidos_rep00499_pedido", "klyibtech_pedidos_rep00203_pedido" });
            String arquivo = $"/home/gabrielts/pedidoskyly{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv";
            System.IO.File.AppendAllText(arquivo, "nomeBase;id;situacaoERP;situacao;dataEmissao;dataFinalizacao;codCliente;razaoSocialCliente;codTabpreco;codProduto;nomeEtiqueta;quantidade;vlrTotalBruto;vlrTotalLiquido");
            String conta = "kly";
            String req = RequestCouchDB(@"https://couchdb-cluster.ibtech.inf.br/_all_dbs");
            if (req == null)
            {
                return;
            }
            JArray bases = JArray.Parse(req);
            List<JToken> basesPedidos = bases.Where(c => c.ToStringJ().StartsWith(conta) && c.ToStringJ().EndsWith("_pedido")).ToList();
            Parallel.ForEach(basesPedidos, (new ParallelOptions { MaxDegreeOfParallelism = 1 }), (nomeBase) =>
           {
               if (jaImportado.Contains(nomeBase.ToString()))
               {
                   return;
               }
               String baseRepStr = RequestCouchDB(@$"https://couchdb-cluster.ibtech.inf.br/{nomeBase.ToStringJ()}/_all_docs");
               if (baseRepStr == null)
               {
                   return;
               }
               JObject baseRep = JObject.Parse(baseRepStr);
               if (Convert.ToInt32(baseRep["total_rows"]) > 0)
               {
                   Console.WriteLine($"Base {nomeBase.ToStringJ()} com {baseRep["total_rows"]} linhas");
                   Parallel.ForEach(baseRep["rows"].Where(a => !a["id"].ToStringJ().StartsWith("original")), (new ParallelOptions { MaxDegreeOfParallelism = 50 }), (pedidoReq) =>
                   {
                       String url = $"https://couchdb-cluster.ibtech.inf.br/{nomeBase.ToStringJ()}/{pedidoReq["id"].ToStringJ()}";
                       try
                       {
                           String pedidoStr = RequestCouchDB(url);
                           if (pedidoStr == null)
                           {
                               return;
                           }
                           JObject pedidoObj = JObject.Parse(pedidoStr);
                           if (pedidoObj == null)
                           {
                               return;
                           }
                           if (pedidoObj["flagExcluido"] == null || pedidoObj["flagExcluido"].ToStringJ() != "1")
                           {
                               String situacao = pedidoObj["situacao"].ToStringJ();
                               String dataEmissao = pedidoObj["dataEmissao"].ToStringJ();
                               if (Int64.Parse(dataEmissao) < 1601089200000 || (!String.IsNullOrEmpty(situacao) && Int32.Parse(situacao) > 40)) {
                                   return;
                               }
                               String codCliente = "";
                               String clienteRazaoSocial = "";
                               if (pedidoObj["cliente"] != null && pedidoObj["cliente"]["codCliente"] != null && pedidoObj["cliente"]["razaoSocial"] != null)
                               {
                                   codCliente = pedidoObj["cliente"]["codCliente"].ToStringJ();
                                   clienteRazaoSocial = pedidoObj["cliente"]["razaoSocial"].ToStringJ();
                               }
                               String situacaoERP = pedidoObj["situacaoERP"] != null ? pedidoObj["situacaoERP"].ToStringJ() : "";
                               String codTabPreco = "";
                               if (pedidoObj["tabelaPreco"] != null)
                               {
                                   codTabPreco = pedidoObj["tabelaPreco"]["codTabPreco"].ToStringJ();
                               }

                               String dataFinalizacao = pedidoObj["dataFinalizacao"].ToStringJ();                               
                               StringBuilder csvStr = new StringBuilder();
                               foreach (var item in pedidoObj["itens"])
                               {
                                   String nomeEtiqueta = nomeEtiqueta = item["produto"]["nomeEtiqueta"].ToStringJ();
                                   String vlrTotalBruto = vlrTotalBruto = item["vlrTotalBrutoIpi"].ToStringJ();
                                   String vlrTotalLiquido = item["vlrTotalLiquidoIpi"].ToStringJ();
                                   csvStr.AppendLine($"{nomeBase.ToStringJ()};{pedidoReq["id"].ToStringJ()};{situacaoERP};{situacao};{dataEmissao};{dataFinalizacao};{codCliente};{clienteRazaoSocial};{codTabPreco};{item["produto"]["codReferencia"].ToStringJ()};{nomeEtiqueta};{item["quantidade"].ToStringJ()};{vlrTotalBruto};{vlrTotalLiquido}");
                               }
                               System.IO.File.AppendAllText(arquivo, csvStr.ToString());
                           }
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine("Erro ao obter: " + url);
                           StringBuilder erro = new StringBuilder();
                           erro.AppendLine();
                           erro.AppendLine(url);
                           erro.AppendLine(ex.Message);
                           erro.AppendLine();
                           System.IO.File.AppendAllText("/home/gabrielts/logcouchdb.log", erro.ToString());
                       }
                   });
               }
               else
               {
                   Console.WriteLine($"Base {nomeBase.ToStringJ()} vazia");
               }
           });
        }

        public static String RequestCouchDB(String url)
        {
            try
            {
                HttpClient client = new HttpClient();
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get,
                };
                client.DefaultRequestHeaders.Clear();
                var authenticationString = "ibtech:dinO4609";
                var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.UTF8.GetBytes(authenticationString));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + base64EncodedAuthenticationString);
                String result = client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao obter: " + url);
                StringBuilder erro = new StringBuilder();
                erro.AppendLine();
                erro.AppendLine(url);
                erro.AppendLine(ex.Message);
                erro.AppendLine();
                System.IO.File.AppendAllText("/home/gabrielts/logcouchdb.log", erro.ToString());
            }
            return null;
        }
    }
}

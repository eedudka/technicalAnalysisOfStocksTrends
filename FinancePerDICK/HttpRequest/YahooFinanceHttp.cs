using FinancePerDICK.HttpRequest.Abstraction;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FinancePerDICK.HttpRequest
{
    public class YahooFinanceHttp : HttpDataCreator
    {
        public YahooFinanceHttp(string StockServiceUri) : base(StockServiceUri)
        {
        }

        public override async Task<bool> ConnectAsync(string UrlAdress)
        {
            using (var httpClient = new HttpClient(new HttpClientHandler()))
            {
                var request = await httpClient.GetAsync(UrlAdress);
                if (request.ReasonPhrase == "OK")
                {
                    return true;
                }
                return false;
            }
        }

        public override async Task<float[]> CreateData()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://query1.finance.yahoo.com/v10/finance/quoteSummary/YNDX.ME?modules=price");
                if (response != null)
                {
                    dynamic JSONYF = JsonConvert.DeserializeObject<dynamic>(response);
                    float lowPrice = JSONYF.quoteSummary.result[0].price.regularMarketDayLow.raw;
                    float hightPrice = JSONYF.quoteSummary.result[0].price.regularMarketDayHigh.raw;
                    float opnePrice = JSONYF.quoteSummary.result[0].price.regularMarketOpen.raw;
                    
                    return new float[] { opnePrice, lowPrice, hightPrice };
                }
                return null;
            }
        }
    }
}

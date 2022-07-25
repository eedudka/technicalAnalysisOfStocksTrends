using System.Threading.Tasks;

namespace FinancePerDICK.HttpRequest.Abstraction
{
    public abstract class HttpDataCreator : IHttpConnect
    {

        public string UrlAdress { get; }
        private bool isConnect { get; }

        string IHttpConnect.UrlAdress => throw new System.NotImplementedException();

        protected HttpDataCreator(string StockServiceUri)
        {
            if (!string.IsNullOrWhiteSpace(StockServiceUri) && ConnectAsync(StockServiceUri).Result)
            {
                UrlAdress = StockServiceUri;
                isConnect = true;
            }

        }

       public abstract Task<bool> ConnectAsync(string UrlAdress);

       public abstract  Task<float[]> CreateData();
    }
}

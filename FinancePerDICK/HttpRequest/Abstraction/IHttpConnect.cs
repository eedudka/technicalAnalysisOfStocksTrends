using System.Threading.Tasks;

namespace FinancePerDICK.HttpRequest.Abstraction
{
    public interface IHttpConnect
    {
        public string UrlAdress { get; }

        Task<float[]> CreateData();
        public Task<bool> ConnectAsync(string UrlAdress);

    }
}

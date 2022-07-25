using System.Threading.Tasks;

namespace FinancePerDICK.HttpRequest.Abstraction
{
    public interface IHttpConnect
    {
        public string UrlAdress { get; }

        Task<float[]> CreateData();
        Task<bool> ConnectAsync(string UrlAdress);

    }
}

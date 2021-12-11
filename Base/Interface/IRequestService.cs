using System.Net.Http;
using System.Threading.Tasks;

namespace Xtramile.Base.Interface
{
    public interface IRequestService
    {
        Task<HttpResponseMessage> REST(string requestUri, RequestEnum restType);
        Task<HttpResponseMessage> REST(string requestUri, RequestEnum restType, string postBody);
        Task<T> ConvertResponseToEntity<T>(HttpResponseMessage message);
    }
}

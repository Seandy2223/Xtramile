using Newtonsoft.Json;
using Xtramile.Base.Interface;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System;
using System.Net.Http.Headers;

namespace Xtramile.Base
{
    public class RequestService : IRequestService
    {
        public RequestService(IFeature feature)
        {
        }

        public async Task<HttpResponseMessage> REST(string requestUri, RequestEnum restType)
        {
            return await REST(requestUri, restType, null);
        }

        public async Task<HttpResponseMessage> REST(string requestUri, RequestEnum restType, string postBody)
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, ChainedBuilderExtensions, sslPolicyErrors) => true);
                System.Net.ServicePointManager.Expect100Continue = true;
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;

                return await GenerateHttpClientAsync(requestUri, restType, postBody);
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        private async Task<HttpResponseMessage> GenerateHttpClientAsync(string requestUri, RequestEnum restType, string postBody)
        {
            HttpResponseMessage result = default(HttpResponseMessage);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-api-version", "1.0");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType.Json));

                if (restType == RequestEnum.GET)
                    result = await client.GetAsync(requestUri);
                else if (restType == RequestEnum.POST)
                    result = await client.PostAsync(requestUri, new StringContent(postBody, Encoding.UTF8, MediaType.Json));
                else if (restType == RequestEnum.DELETE)
                    result = await client.DeleteAsync(requestUri);
                else
                    result = await client.GetAsync(requestUri);

                result.EnsureSuccessStatusCode();
            }

            return result;
        }

        public async Task<T> ConvertResponseToEntity<T>(HttpResponseMessage message)
        {
            var stringContent = await message.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<T>(stringContent);
            if (response != null)
            {
                return response;
            }
            else
                return default(T);
        }
    }
}

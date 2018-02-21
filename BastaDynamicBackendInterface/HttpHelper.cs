using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App1
{
    public class HttpHelper
    {
        internal async Task Post(object user, string method, string contentType = "application/json")
        {
            var uri = Resources.EndpointUri;
            using (var wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = contentType;
                await wc.UploadStringTaskAsync(uri, method, JsonConvert.SerializeObject(user));
            }
        }

        internal async Task<object> Get()
        {
            var uri = Resources.EndpointUri;
            using (var wc = new WebClient())
            {
                return JsonConvert.DeserializeObject<object>(await wc.DownloadStringTaskAsync(uri));
            }
        }
    }
}

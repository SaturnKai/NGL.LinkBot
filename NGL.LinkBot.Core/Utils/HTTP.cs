using System.Net.Http;
using System.Net.Http.Headers;

namespace NGL.LinkBot.Core.Utils
{
    public class HTTP
    {
        public static HttpResponseMessage Get(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                    request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));

                    HttpResponseMessage response = client.SendAsync(request).Result;
                    return response;
                }
            } catch
            {
                return null;
            }
        }

        public static HttpResponseMessage Post(string url, HttpContent data)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                    request.Content = data;
                    request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));

                    HttpResponseMessage response = client.SendAsync(request).Result;
                    return response;
                }
            } catch
            {
                return null;
            }
        }
    }
}
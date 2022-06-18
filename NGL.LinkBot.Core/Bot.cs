using System.Net;
using System.Net.Http;
using System.Collections.Generic;

using NGL.LinkBot.Core.Utils;

namespace NGL.LinkBot.Core
{
    public class Bot
    {
        public static bool ProfileExists(string name)
        {
            HttpResponseMessage response = HTTP.Get($"https://ngl.link/{name}");
            return response != null && response.StatusCode == HttpStatusCode.OK;
        }

        public static bool SendMessage(string profile, string message)
        {
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                { "question", message }
            };

            HttpResponseMessage response = HTTP.Post($"https://ngl.link/{profile}", new FormUrlEncodedContent(data));
            return response != null && response.StatusCode == HttpStatusCode.OK;
        }
    }
}
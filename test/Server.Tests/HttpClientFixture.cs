using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Server.Tests
{
    public class HttpClientFixture
    {
        public static string BaseAddress = "http://localhost:5000/";

        public readonly HttpClient Client;

        public HttpClientFixture()
        {
            Client = new HttpClient();

            Client.BaseAddress = new Uri(BaseAddress);
            Client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

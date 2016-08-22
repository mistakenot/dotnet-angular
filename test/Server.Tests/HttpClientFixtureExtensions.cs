using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace Server.Tests
{
    public static class HttpClientFixtureExtensions
    {
        public const string DefaultEmail = "bob@email.com";
        public const string Password = "!23Qwe";

        public static async Task LoginAsync(
            this HttpClient client,
            string email = DefaultEmail,
            string password = Password)
        {
            var model = new { Email = email, Password = password, RememberMe = false };
            var response = await client.PostAsync(
                "Account/Login",
                model.ToJson());

            if (response.StatusCode == (HttpStatusCode)404)
            {
                await RegisterAsync(client);
                await LoginAsync(client);
            }
            else
            {
                Assert.Equal(200, (int)response.StatusCode);
                client.DefaultRequestHeaders.Add(
                    "Cookie",
                    response.Headers.GetValues("Set-Cookie"));

                foreach (var header in client.DefaultRequestHeaders.GetValues("Cookie"))
                {
                    Console.WriteLine(header);
                }

                // Check that it has worked
                response = await client.GetAsync("Account");
                Assert.True(response.IsSuccessStatusCode);
            }
        }

        public static async Task RegisterAsync(
            this HttpClient client,
            string email = DefaultEmail,
            string password = Password)
        {
            var model = new { Email = email, Password = password, ConfirmPassword = password }.ToJson();
            var response = await client.PostAsync(
                "Account/Register",
                model);

            Assert.Equal(201, (int)response.StatusCode);
        }

        public static async Task LogoutAsync(this HttpClient client)
        {
            var response = await client.PostAsync("Account/LogOff", new { }.ToJson());
            Assert.Equal(200, (int)response.StatusCode);
        }

        public static StringContent ToJson(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

    }
}

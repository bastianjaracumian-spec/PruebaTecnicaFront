using FrontAtencionesMedicas.Models.Patient;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Security.Policy;
namespace FrontAtencionesMedicas.ExternalServices.Authenticator
{
    public class AuthenticatorServices
    {
        public async Task<String> GetTokenUser()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7279/Api/Authenticator/GetTokenUser/19517569-1/prueba/1");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            var respuesta = await response.Content.ReadAsStringAsync();
            var deserialize = JsonConvert.DeserializeObject<Data>(respuesta);
            return deserialize.data;
        }
        public class Data
        {
            public string data { get; set; }
        }
    }
}

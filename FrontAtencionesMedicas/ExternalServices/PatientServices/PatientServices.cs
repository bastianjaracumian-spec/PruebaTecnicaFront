using FrontAtencionesMedicas.ExternalServices.Authenticator;
using FrontAtencionesMedicas.Models.Patient;
using Newtonsoft.Json;

using FrontAtencionesMedicas.ExternalServices.Authenticator;
namespace FrontAtencionesMedicas.ExternalServices.PatientServices
{
    public class PatientServices
    {
        AuthenticatorServices authenticatorServices = new AuthenticatorServices();
        public async Task<Data> GetUsers()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7279/Api/Patient/GetUsers");
            var token = await authenticatorServices.GetTokenUser();
            request.Headers.Add("Authorization", "Bearer " + token);
            var collection = new List<KeyValuePair<string, string>>();
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            var respuesta = await response.Content.ReadAsStringAsync();
            var deserialize = JsonConvert.DeserializeObject<Data>(respuesta);
            return deserialize;
        }
    }
}

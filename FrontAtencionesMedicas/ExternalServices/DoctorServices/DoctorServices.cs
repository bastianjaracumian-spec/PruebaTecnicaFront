using FrontAtencionesMedicas.ExternalServices.Authenticator;
using FrontAtencionesMedicas.Models.Doctor;
using Newtonsoft.Json;

namespace FrontAtencionesMedicas.ExternalServices.DoctorServices
{
    public class DoctorServices
    {
        AuthenticatorServices authenticatorServices = new AuthenticatorServices();
        public async Task<Data> GetDoctors()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7279/Api/Doctor/GetDoctors");
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

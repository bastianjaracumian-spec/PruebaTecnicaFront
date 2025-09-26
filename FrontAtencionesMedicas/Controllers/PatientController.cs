using FrontAtencionesMedicas.Models.Patient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FrontAtencionesMedicas.Controllers
{
    public class PatientController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7279/Api");
        private readonly HttpClient _client;
        public PatientController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<PatientDAO> patients = new List<PatientDAO>();
            HttpResponseMessage response =  _client.GetAsync(_client.BaseAddress + "/Patient/GetUsers").Result;
            if (response.IsSuccessStatusCode)
            {
                string data =  response.Content.ReadAsStringAsync().Result;
                patients = JsonConvert.DeserializeObject<List<PatientDAO>>(data);
            }
            return View(patients);
        }
    }
}

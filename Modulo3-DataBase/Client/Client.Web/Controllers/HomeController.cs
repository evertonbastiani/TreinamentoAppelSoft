using Client.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace Client.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        const string urlBase = "http://localhost:8085/TipoVeiculo/";

		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async  Task<IActionResult> Index()
        {

            //https://localhost:44348/TipoVeiculo/
            var urlGet = $"{urlBase}List";
            List<TipoVeiculoModel> tipoVeicluoModel = new List<TipoVeiculoModel>();
            using (HttpClient clientRequest = new HttpClient())
            {
                var tipoVeiculoResponse = await clientRequest.GetStringAsync(urlGet);
                tipoVeicluoModel = JsonConvert.DeserializeObject<List<TipoVeiculoModel>>(tipoVeiculoResponse);
            }
            

            return View(tipoVeicluoModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TipoVeiculoModel model)
        {
			var urlInsert = $"{urlBase}Insert";
			using (var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json"))
			{
                using (HttpClient client = new HttpClient())
                {
					HttpResponseMessage result = client.PostAsync(urlInsert, content).Result;
					return RedirectToAction("Index", "Home");

					
					
				}
				
			}
		}

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var urlGet = $"{urlBase}Get?Id={id}";
            TipoVeiculoModel tipoVeiculoModel = new TipoVeiculoModel();
            using (HttpClient clientRequest = new HttpClient())
            {
                var tipoVeiculoResponse = await clientRequest.GetStringAsync(urlGet);
                tipoVeiculoModel = JsonConvert.DeserializeObject<TipoVeiculoModel>(tipoVeiculoResponse);
            }
            return View(tipoVeiculoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Descricao")] TipoVeiculoModel model)
        {
            var urlInsert = $"{urlBase}Update";
            using (var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json"))
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage result = client.PutAsync(urlInsert, content).Result;
                    return  RedirectToAction("Index", "Home");



                }

            }

            
        }
    }
}
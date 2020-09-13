using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TP1_Mvc_Consume.Helper;
using TP1_Mvc_Consume.Models;

namespace TP1_Mvc_Consume.Controllers
{
    public class PessoasController : Controller
    {
        PessoaApi _api = new PessoaApi();

        // GET: PessoasController
        public async Task<ActionResult> Index()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/pessoas");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(result);
            }
            return View(pessoas);
        }

        // GET: PessoasController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var pessoa = new Pessoa();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/pessoas/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                pessoa = JsonConvert.DeserializeObject<Pessoa>(result);
            }
            return View(pessoa);
        }

        // GET: PessoasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoasController/Create
        [HttpPost]
        public async Task<IActionResult> Create(Pessoa pessoa)
        {
            Pessoa recivePessoa = new Pessoa();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(pessoa), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:65089/api/amigos", content))
                {
                    string apiResponse = await
                    response.Content.ReadAsStringAsync();
                    recivePessoa = JsonConvert.DeserializeObject<Pessoa>(apiResponse);
                }
            }
            return View(recivePessoa);
        }

        // GET: PessoasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PessoasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoasController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var pessoa = new Pessoa();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/amigos/{id}");
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("Index");
        }

        // POST: PessoasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

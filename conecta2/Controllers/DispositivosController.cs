﻿using Microsoft.AspNetCore.Mvc;

namespace conecta2.Controllers
{
    public class DispositivosController : Controller
    {
        // Estado del foco (true: encendido, false: apagado)
        private static bool _isFocoEncendido = false;

        private HttpClient _httpClient = new();

        public IActionResult Dispositivos()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> ToggleFoco(bool encender)
        {
            string urlBase = "http://192.168.0.16/";

            if (encender)
            {
                HttpResponseMessage response = await _httpClient.GetAsync(urlBase + "LED=ON");
                string mensaje = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                _isFocoEncendido = true;
                return Json(new { message = "Foco encendido." });
            }
            else
            {
                HttpResponseMessage response = await _httpClient.GetAsync(urlBase + "LED=OFF");
                string mensaje = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                _isFocoEncendido = false;
                return Json(new { message = "Foco apagado." });
            }
        }
    }
}


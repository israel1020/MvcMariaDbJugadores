using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcMariaDbJugadores.Models;
using MvcMariaDbJugadores.Repositories;
using MvcMariaDbJugadores.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMariaDbJugadores.Controllers
{
    public class JugadoresController : Controller
    {
        private RepositoryJugadores repository;
        private ServiceAWSS3 service;
        public JugadoresController(RepositoryJugadores repository, ServiceAWSS3 service)
        {
            this.repository = repository;
            this.service = service;
        }
        public IActionResult Jugadores()
        {
            return View(this.repository.GetJugadores());
        }
        public IActionResult NewJugador()
        {
            List<Equipo> equipos = this.repository.GetEquipos();
            ViewData["EQUIPOS"] = equipos;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewJugador(Jugador jugador, IFormFile imagen)
        {
            string name = imagen.FileName;
            using (Stream stream = imagen.OpenReadStream())
            {
                await this.service.UploadFileAsync(stream, name);
            }
            jugador.Imagen = name;

            this.repository.InsertJugador(jugador.Nombre, jugador.Posicion, jugador.Imagen, jugador.IdEquipo);
            return RedirectToAction("Jugadores");
        }
        public IActionResult Equipos()
        {
            return View(this.repository.GetEquipos());
        }
        public IActionResult Apuestas()
        {
            return View(this.repository.GetApuestas());
        }
        public IActionResult NewApuesta()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewApuesta(Apuesta apuesta)
        {
            this.repository.InsertApuesta(apuesta.Usuario, apuesta.IdEquipoLocal, apuesta.IdEquipoVisitante, apuesta.GolesEquipoLocal, apuesta.GolesEquipoVisitante);
            return RedirectToAction("Apuestas");
        }

    }
}

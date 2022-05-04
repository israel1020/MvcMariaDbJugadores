using MvcMariaDbJugadores.Data;
using MvcMariaDbJugadores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMariaDbJugadores.Repositories
{
    public class RepositoryJugadores
    {
        private JugadoresContext context;
        public RepositoryJugadores(JugadoresContext context)
        {
            this.context = context;
        }
        public List<Jugador> GetJugadores()
        {
            return this.context.Jugadores.ToList();
        }
        public List<Equipo> GetEquipos()
        {
            return this.context.Equipos.ToList();
        }
        public List<Apuesta> GetApuestas()
        {
            return this.context.Apuestas.ToList();
        }
        public int MaxIdJugador()
        {
            int numero = this.context.Jugadores.Count();
            if(numero == 0)
            {
                return 1;
            }
            else
            {
                return numero + 1;
            }
        }
        public int MaxIdApuesta()
        {
            int numero = this.context.Apuestas.Count();
            if (numero == 0)
            {
                return 1;
            }
            else
            {
                return numero + 1;
            }
        }
        public void InsertJugador(string nombre, string posicion, string imagen, int idequipo) 
        {
            Jugador jugador = new Jugador();
            jugador.IdJugador = this.MaxIdJugador();
            jugador.Nombre = nombre;
            jugador.Posicion = posicion;
            jugador.Imagen = imagen;
            jugador.IdEquipo = idequipo;
            this.context.Jugadores.Add(jugador);
            this.context.SaveChanges();
        }
        public void InsertApuesta(string usuario, int idequipolocal, int idequipovisitante, int golesequipolocal, int golesequipovisitante)
        {
            Apuesta apuesta = new Apuesta();
            apuesta.IdApuesta = this.MaxIdApuesta();
            apuesta.Usuario = usuario;
            apuesta.IdEquipoLocal = idequipolocal;
            apuesta.IdEquipoVisitante = idequipovisitante;
            apuesta.GolesEquipoLocal = golesequipolocal;
            apuesta.GolesEquipoVisitante = golesequipovisitante;
            this.context.Apuestas.Add(apuesta);
            this.context.SaveChanges();
        }
    }
}

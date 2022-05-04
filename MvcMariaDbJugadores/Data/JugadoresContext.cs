using Microsoft.EntityFrameworkCore;
using MvcMariaDbJugadores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMariaDbJugadores.Data
{
    public class JugadoresContext:DbContext
    {
        public JugadoresContext(DbContextOptions<JugadoresContext> options) : base(options) { }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }
    }
}

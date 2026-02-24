using CalculadoraPekus.Application.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CalculadoraPekus.API.Contextos
{
    public class CalculadoraContexto : DbContext
    {
        public CalculadoraContexto(DbContextOptions<CalculadoraContexto> options) : base(options) { }
        public DbSet<CalculoModel> Calculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

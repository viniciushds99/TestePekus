using CalculadoraPekus.Application.Models;
using CalculadoraPekus.Application.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraPekus.Application.Interfaces
{
    public interface ICalculadoraRepository
    {
        public Task<CalculoModel> Inserir(CalculoRequest calculoResquest);
        public void Deletar(int id);
        public Task<List<CalculoModel>> Select();
        public void TruncateTable();
    }
}

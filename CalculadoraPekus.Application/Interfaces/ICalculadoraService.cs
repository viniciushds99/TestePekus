using CalculadoraPekus.Application.Models;
using CalculadoraPekus.Application.Models.Request;

namespace CalculadoraPekus.Application.Interfaces
{
    public interface ICalculadoraService
    {
        public Task<CalculoModel> SalvaCalculo(CalculoRequest calculoRequest);

        public void DeletaCalculo(int id);

        public Task<List<CalculoModel>> ListaCalculos();

        public void DeletaRegistros();
    }
}

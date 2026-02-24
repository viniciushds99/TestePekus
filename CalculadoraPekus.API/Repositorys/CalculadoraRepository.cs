using CalculadoraPekus.API.Contextos;
using CalculadoraPekus.Application.Interfaces;
using CalculadoraPekus.Application.Models;
using CalculadoraPekus.Application.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraPekus.API.Repositorys
{
    public class CalculadoraRepository: ICalculadoraRepository
    {
        private readonly CalculadoraContexto _calculadoraContexto;

        public CalculadoraRepository(CalculadoraContexto calculadoraContexto)
        {
            _calculadoraContexto = calculadoraContexto;
        }
        public async Task<CalculoModel> Inserir(CalculoRequest calculoRequest)
        {
            CalculoModel calculo = new CalculoModel()
            {
                ValorA = calculoRequest.ValorA,
                ValorB = calculoRequest.ValorB,
                Operacao = calculoRequest.Operacao,
                Resultado = calculoRequest.Resultado,
                DataCalculo = calculoRequest.DataCalculo,
            };
            _calculadoraContexto.Add(calculo);
            await _calculadoraContexto.SaveChangesAsync();

            return calculo;
        }

        public void Deletar(int id)
        {
            var calculo = _calculadoraContexto.Calculos.Find(id);

            if (calculo == null)
                throw new Exception("Calculo não encontrado");

            _calculadoraContexto.Calculos.Remove(calculo);
            _calculadoraContexto.SaveChanges();
        }

        public async Task<List<CalculoModel>> Select()
        {
            var listaCalculos = await _calculadoraContexto.Calculos.ToListAsync();
            return listaCalculos;
        }

        public void TruncateTable()
        {
            _calculadoraContexto.Calculos.ExecuteDelete();
        }
    }
}

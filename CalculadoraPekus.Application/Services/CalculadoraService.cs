using CalculadoraPekus.Application.Interfaces;
using CalculadoraPekus.Application.Models;
using CalculadoraPekus.Application.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraPekus.Application.Services
{
    public class CalculadoraService: ICalculadoraService
    {
        private readonly ICalculadoraRepository _calculadoraRepository;
        public CalculadoraService(ICalculadoraRepository calculadoraRepository) 
        {
            _calculadoraRepository = calculadoraRepository;
        }
        public async Task<CalculoModel> SalvaCalculo(CalculoRequest calculoRequest) 
        { 
           return await _calculadoraRepository.Inserir(calculoRequest);
        }

        public void DeletaCalculo(int id)
        {
            _calculadoraRepository.Deletar(id);
        }

        public async Task<List<CalculoModel>> ListaCalculos()
        {
           return await _calculadoraRepository.Select();
        }

        public void DeletaRegistros()
        {
            _calculadoraRepository.TruncateTable();
        }
    }
}

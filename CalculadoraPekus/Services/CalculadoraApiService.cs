using CalculadoraPekus.Application.Models;
using CalculadoraPekus.Application.Models.Request;
using System.Net.Http.Json;

namespace CalculadoraPekus.Services
{
    public class CalculadoraApiService
    {
        private readonly HttpClient _http;
        private const string ApiKey = "VN202602";

        public CalculadoraApiService(HttpClient http)
        {
            _http = http;
            _http.DefaultRequestHeaders.Remove("ApiKey");
            _http.DefaultRequestHeaders.Add("ApiKey", ApiKey);
        }
        public async Task<CalculoModel?> SalvarCalculo(CalculoRequest request)
        {
            var response = await _http.PostAsJsonAsync("/api/Calculadora", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CalculoModel>();
        }
        public async Task<List<CalculoModel>> BuscarTodos()
        {
            var lista = await _http.GetFromJsonAsync<List<CalculoModel>>("/api/Calculadora");
            return lista ?? new List<CalculoModel>();
        }
        public async Task Excluir(int id)
        {
            var response = await _http.DeleteAsync($"/api/Calculadora/{id}");
            response.EnsureSuccessStatusCode();
        }
        public async Task LimparTudo()
        {
            var response = await _http.GetAsync("/api/Calculadora/LimpaContas");
            response.EnsureSuccessStatusCode();
        }
    }
}

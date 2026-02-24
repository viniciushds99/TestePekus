namespace CalculadoraPekus.Application.Models
{
    public class CalculoModel
    {
        public int Id { get; set; }
        public double ValorA { get; set; }
        public double ValorB { get; set; }
        public string Operacao { get; set; } = string.Empty;
        public double Resultado { get; set; }
        public DateTime DataCalculo { get; set; }
    }
}

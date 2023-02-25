namespace Classes.Statics
{

    public static class Frete
    {
        private const decimal fatorCalculo = 5.98M;

        public static decimal CalcularFrete(decimal distancia)
        {
            return distancia * fatorCalculo;
        }
    }
}

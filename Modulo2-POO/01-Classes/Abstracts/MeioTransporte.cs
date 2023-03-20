namespace Classes.Abstracts
{
    public abstract class MeioTransporte
    {
        public abstract void tipoCombustivel();
       
        public void ExibirMeioTransporte()
        {
            Console.WriteLine($"Isto é um meio de transporte. {base.GetType().Name}");
        }
    }
}

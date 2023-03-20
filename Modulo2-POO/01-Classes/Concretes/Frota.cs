namespace Classes.Concretes
{
    public class Frota
    {
        public string Descricao { get; set; }
        public List<Veiculo> Veiculos { get; set; }

        public Frota()
        {
            Veiculos = new List<Veiculo>();

        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            Veiculos.Add(veiculo);
        }

        public List<Veiculo> ListarVeiculos()
        {
            return Veiculos;
        }
    }
}

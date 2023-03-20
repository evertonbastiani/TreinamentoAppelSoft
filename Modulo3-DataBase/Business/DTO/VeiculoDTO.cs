namespace Curso.Domain.DTO
{
    public class VeiculoDTO
    {
        public long Id { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int Ano { get; set; }
        public string? Cor { get; set; }
        public string? Placa { get; set; }
        public TipoVeiculoDTO Tipo {get;set;}

        public VeiculoDTO() { 
        
            this.Tipo = new TipoVeiculoDTO();
        }
    }
}

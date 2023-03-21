namespace Curso.Domain.DTO
{
    public class UsuarioDTO
    {
       
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Token { get; set; }

    }
}

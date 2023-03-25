namespace Curso.API.Model
{
    public class LoginRequestModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Enviado pelo front.
        /// </summary>
        public int ProductId { get; set; }
    }
}

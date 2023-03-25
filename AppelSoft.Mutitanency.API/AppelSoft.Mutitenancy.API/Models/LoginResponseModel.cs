using AppelSoft.Mutitenancy.API.Models;

namespace Curso.API.Model
{
    public class LoginResponseModel:BaseResponseModel
    {
        public LoginResponseModel()
        {
            this.Messages = new List<string>();
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }      
        public string Token { get; set; }

        public int IdEmpresa { get; set; }
    }
}

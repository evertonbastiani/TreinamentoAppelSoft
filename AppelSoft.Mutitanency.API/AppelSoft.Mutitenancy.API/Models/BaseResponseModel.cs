using System.Net;

namespace AppelSoft.Mutitenancy.API.Models
{
    public class BaseResponseModel
    {
        /// <summary>
        /// Lista de mensagens de retorno
        /// </summary>
        public IList<string> Messages { get; set; }

        /// <summary>
        /// Lista de Erros
        /// </summary>
        public int Errors { get; set; }

        /// <summary>
        /// Status da requisição
        /// </summary>
        public HttpStatusCode Status { get; set; }


        protected BaseResponseModel ResponseBadRequest(string message)
        {
            this.Status = HttpStatusCode.BadRequest;
            this.Errors = 1;
            this.Messages.Add(message);
            return this;
        }
    }
}

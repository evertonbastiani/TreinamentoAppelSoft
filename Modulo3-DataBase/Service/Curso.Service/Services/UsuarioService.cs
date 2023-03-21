using Curso.Domain.DTO;
using Curso.Domain.Entities;
using Curso.Repository.Interfaces;
using Curso.Service.Authentication;
using Curso.Service.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Curso.Service.Services
{
    public class UsuarioService: ServiceBase, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        protected const string chaveCriptografia = "*E/-R{N}A#@K!H";
        private static byte[] chave = { };
        private static byte[] iv = { 12, 34, 56, 78, 90, 102, 114, 126 };

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool Delete(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("id", "O Id do usuário não foi informado.");
            }

            return _usuarioRepository.Delete(id);
        }

        public UsuarioDTO Get(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("id", "O Id do usuário não foi informado.");
            }
            var usuario = _usuarioRepository.Get(id);
            return mapper.Map<UsuarioDTO>(usuario);
        }

        public UsuarioDTO Insert(UsuarioDTO usuarioDto)
        {
            //Validação do Login
            if (String.IsNullOrEmpty(usuarioDto.Login))
            {
                throw new ArgumentNullException("Login", "O campo Login é obrigatório.");
            }
            if (String.IsNullOrEmpty(usuarioDto.Senha))
            {
                throw new ArgumentNullException("Senha", "O campo Senha é obrigatório.");
            }

            usuarioDto.Senha = this.Criptografar(usuarioDto.Senha, chaveCriptografia);
            Usuario usuario = mapper.Map<Usuario>(usuarioDto);
            usuario = _usuarioRepository.Insert(usuario);
            return mapper.Map<UsuarioDTO>(usuario);
        }

        public List<UsuarioDTO> List()
        {
            List<Usuario> listUsuarios = _usuarioRepository.List();
            return mapper.Map<List<UsuarioDTO>>(listUsuarios);
        }

        public UsuarioDTO Login(string login, string senha)
        {
            if (String.IsNullOrEmpty(login))
            {
                throw new ArgumentNullException("Login", "O campo Login é obrigatório.");
            }

            if (String.IsNullOrEmpty(senha))
            {
                throw new ArgumentNullException("Senha", "O campo Senha é obrigatório.");
            }
            var senhaCriptografada = this.Criptografar(senha, chaveCriptografia);
            var usuario = _usuarioRepository.Login(login, senhaCriptografada);
            if(usuario != null)
            {
                UsuarioDTO usuarioDTO = mapper.Map<UsuarioDTO>(usuario);
                usuarioDTO.Token = TokenGeneration.GenerateToken(usuarioDTO.Login);
                return usuarioDTO;
            }
            else
            {
                return null;
            }
           
        }

        public UsuarioDTO Update(UsuarioDTO usuarioDto)
        {
            //Validação do Login
            if (String.IsNullOrEmpty(usuarioDto.Login))
            {
                throw new ArgumentNullException("Login", "O campo Login é obrigatório.");
            }

            if (String.IsNullOrEmpty(usuarioDto.Senha))
            {
                throw new ArgumentNullException("Senha", "O campo Senha é obrigatório.");
            }

            Usuario usuario = mapper.Map<Usuario>(usuarioDto);
            usuario = _usuarioRepository.Update(usuario);

            return mapper.Map<UsuarioDTO>(usuario);
        }

        private string Criptografar(string valor, string chaveCriptografia)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs; byte[] input;

            try
            {
                des = new DESCryptoServiceProvider();
                ms = new MemoryStream();
                input = Encoding.UTF8.GetBytes(valor);
                chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));

                cs = new CryptoStream(ms, des.CreateEncryptor(chave, iv), CryptoStreamMode.Write);
                cs.Write(input, 0, input.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
       
    }
}

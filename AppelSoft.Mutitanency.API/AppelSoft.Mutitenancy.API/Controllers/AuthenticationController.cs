using AppelSoft.Mutitenancy.API.Authentication;
using AppelSoft.Mutitenancy.API.Repository.Entities;
using AppelSoft.Mutitenancy.API.Repository.Interface;
using Curso.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Xml.Linq;

namespace AppelSoft.Mutitenancy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IUserRepository _usuarioRepository;
        private readonly ICompanyProductRepository _companyProductRepository;
        private readonly IProductRepository _productRepository;


        protected const string chaveCriptografia = "*E/-R{N}A#@K!H";
        private static byte[] key = { };
        private static byte[] iv = { 12, 34, 56, 78, 90, 102, 114, 126 };

        public AuthenticationController(IUserRepository usuarioRepository,
                                        ICompanyProductRepository companyProductRepository,
                                        IProductRepository productRepository)
        {
            _usuarioRepository = usuarioRepository;
            _companyProductRepository = companyProductRepository;
            _productRepository = productRepository;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequestModel requestModel)
        {
            LoginResponseModel responseModel = new LoginResponseModel();
            try
            {
                if (String.IsNullOrEmpty(requestModel.Login) || string.IsNullOrEmpty(requestModel.Password))
                {
                    throw new Exception("Login ou senha não foram informados.");
                }

                //User authentication
                var encrypedPassword = this.Criptografar(requestModel.Password, chaveCriptografia);
                var oUsuario = _usuarioRepository.Login(requestModel.Login, encrypedPassword);
                if (oUsuario != null)
                {
                    
                    var companyProduct = _companyProductRepository.GetProduct(requestModel.ProductId);                   
                    if(companyProduct != null)
                    {
                        var product = _productRepository.GetProduct(companyProduct.Id_Product);
                        if(companyProduct.Active && companyProduct.Expiration_Date < DateTime.Now)
                        {
                            throw new Exception($"Sua versão do {product.Name} trial expirou. Entre contato com a administração.");
                        }

                        if (!companyProduct.Active)
                        {
                            responseModel.IdUsuario = oUsuario.Id;
                            responseModel.IdEmpresa = oUsuario.Companyid;
                            responseModel.Nome = oUsuario.Nome;
                            responseModel.Login = oUsuario.Login;
                            responseModel.Status = System.Net.HttpStatusCode.UnavailableForLegalReasons;
                            responseModel.Errors = 1;
                            responseModel.Messages.Add($"Não foi possível executar o login para o {product.Name}");
                            return StatusCode(451, responseModel);
                        }

                        responseModel.IdUsuario = oUsuario.Id;
                        responseModel.IdEmpresa = oUsuario.Companyid;
                        responseModel.Nome = oUsuario.Nome;
                        responseModel.Login = oUsuario.Login;
                        responseModel.Status = System.Net.HttpStatusCode.OK;
                        responseModel.Errors = 0;
                        responseModel.Token = TokenGeneration.GenerateToken(oUsuario.Login);
                        return Ok(responseModel);
                    }
                    else
                    {
                        return NotFound("Não foram encontrados produtos para este usuário.");
                    }
                   

                   
                }

            }
            catch (Exception erro)
            {
                responseModel.Token = string.Empty;
                responseModel.Status = System.Net.HttpStatusCode.BadRequest;
                responseModel.Errors = 1;
                responseModel.IdEmpresa = 0;
                responseModel.Messages.Add(erro.Message);
                return BadRequest(responseModel);
            }
            return View();
        }

        [HttpPost]
        [Route("Insert")]
        [Authorize()]
        public IActionResult Insert(User user)
        {
            try
            {
                return Ok(_usuarioRepository.Insert(user));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }

        private string Criptografar(string value, string chaveCriptografia)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs; byte[] input;

            try
            {
                des = new DESCryptoServiceProvider();
                ms = new MemoryStream();
                input = Encoding.UTF8.GetBytes(value);
                key = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));

                cs = new CryptoStream(ms, des.CreateEncryptor(key, iv), CryptoStreamMode.Write);
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

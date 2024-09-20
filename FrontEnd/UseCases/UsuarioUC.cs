using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FrontEnd.UseCases
{
    public class UsuarioUC
    {
        private readonly HttpClient _client;
        public UsuarioUC(HttpClient client)
        {
            _client = client;
        }
        public List<Usuario> ListarUsuario()
        {
           return _client.GetFromJsonAsync<List<Usuario>>("Usuario/listar-usuario").Result;
            
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            //string apiURL = "https://localhost:7096/Usuario/adicionar-usuario";
            //using HttpClient client = new HttpClient();//para fazer o send/Criar a conexão
            //string jsonRequest = JsonSerializer.Serialize(usuario);
            //HttpResponseMessage response = await client.PostAsJsonAsync(apiURL, jsonRequest);

            HttpResponseMessage response = _client.PostAsJsonAsync("Usuario/adicionar-usuario", usuario).Result;

        }
    }
}

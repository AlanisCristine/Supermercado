using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core._03_Entidades.DTO;
using FrontEnd.Models;

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
            HttpResponseMessage response = _client.PostAsJsonAsync("Usuario/adicionar-usuario", usuario).Result;
        }
        public Usuario FazerLogin(UsuarioLoginDTO usuarioLogin)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Usuario/Fazer-Login", usuarioLogin).Result; //Simula um clique que vc da no execute do swagger
            Usuario usuario = response.Content.ReadFromJsonAsync<Usuario>().Result;
            return usuario;
        }
    }
}

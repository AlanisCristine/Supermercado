using FrontEnd.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd;

public class Sistema
{
    private readonly UsuarioUC _usuarioUC;

    public Sistema(HttpClient client)
    {
        _usuarioUC = new UsuarioUC(client);
    }

    public void IniciarSistema()
    {
        int resposta = -1;

        while (resposta != 0)
        {
            resposta = ExibirLogin();
            if (resposta == 2)
            {
                Usuario usuario = CriarUsuario();
                _usuarioUC.CadastrarUsuario(usuario);
                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            else if (resposta == 3)
            {
                List<Usuario> ususarios = _usuarioUC.ListarUsuario();
                foreach (Usuario u in ususarios)
                {
                    Console.WriteLine(u.ToString());
                }
            }
        }
    }
    public int ExibirLogin()
    {
        Console.WriteLine("------ LOGIN ------");
        Console.WriteLine("1 - Deseja fazer login");
        Console.WriteLine("2 - Deseja se cadastrar");
        Console.WriteLine("3 - Listar usuario cadastrado");
        return int.Parse(Console.ReadLine());
    }

    public Usuario CriarUsuario()
    {
        Usuario usuario = new Usuario();
        Console.WriteLine("Qual é o seu nome?");
        usuario.nome = Console.ReadLine();
        Console.WriteLine("Qual é o seu username?");
        usuario.username = Console.ReadLine();
        Console.WriteLine("Qual é a sua senha?");
        usuario.senha = Console.ReadLine();
        Console.WriteLine("Qual é o seu email?");
        usuario.email = Console.ReadLine();

        return usuario;
    }
}

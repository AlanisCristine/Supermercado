using Core._03_Entidades.DTO;
using FrontEnd.Models;
using FrontEnd.Models.DTO;
using FrontEnd.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd;

public class Sistema
{
    private readonly UsuarioUC _usuarioUC;
    private readonly ProdutoUC _produtoUC;
    private readonly CarrinhoUC _carrinhoUC;
    public Produto IdProd { get; set; }
    private static Usuario UsuarioLogado { get; set; }

    public Sistema(HttpClient client)
    {
        _usuarioUC = new UsuarioUC(client);
        _produtoUC = new ProdutoUC(client);
        _carrinhoUC = new CarrinhoUC(client);
    }

    public void IniciarSistema()
    {
        int resposta = -1;

        while (resposta != 0)
        {
            if (UsuarioLogado == null)
            {
                resposta = ExibirLogin();
                if (resposta == 1)
                {
                    FazerLogin();
                }
                else if (resposta == 2)
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
            else
            {
                ExibirMenuPrincipal();
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
    public void FazerLogin()
    {
        Console.WriteLine("Digite seu username?");
        string username = Console.ReadLine();
        Console.WriteLine("Digite sua senha?");
        string senha = Console.ReadLine();
        UsuarioLoginDTO usuDTO = new UsuarioLoginDTO
        {
            Username = username,
            Senha = senha
        };
        Usuario usuario = _usuarioUC.FazerLogin(usuDTO);
        if (usuario == null)
        {
            Console.WriteLine("Não foi possível fazer o login. Usuário ou senha inválidos");
        }
        UsuarioLogado = usuario;
        Console.WriteLine("Logado");

    }

    public void ExibirMenuPrincipal()
    {
        Console.WriteLine("1 - Listar Produtos");
        Console.WriteLine("2 - Cadastrar Produtos");
        Console.WriteLine("3 - Realizar uma compra");
        Console.WriteLine("Qual ação você deseja realizar?");
        int resposta = int.Parse(Console.ReadLine());

        if (resposta == 1)
        {

            List<Produto> produtos = _produtoUC.ListarProduto();
            foreach (Produto p in produtos)
            {
                Console.WriteLine(p.ToString());
            }

        }
        else if (resposta == 2)
        {
            Produto produto = CriarProduto();
            _produtoUC.CadastrarProduto(produto);
            Console.WriteLine("Usuário cadastrado com sucesso!");
        }
        else if (resposta == 3)
        {
            List<Produto> produtos = _produtoUC.ListarProduto();
            foreach (Produto p in produtos)
            {
                Console.WriteLine(p.ToString());
            }
            Carrinho carrinho = RealizarCompra();
            _carrinhoUC.ComprarProduto(carrinho);
        }

    }
    public Produto CriarProduto()
    {
        Produto pro = new Produto();
        Console.WriteLine("Qual é o Produto?");
        pro.Nome = Console.ReadLine();
        Console.WriteLine("Qual é o preço?");
        pro.Preco = int.Parse(Console.ReadLine());
        Console.WriteLine("Produto cadastrado com sucesso");
        return pro;
    }

    public Carrinho RealizarCompra()
    {
        int resposta = 1;
        Carrinho car = new Carrinho();
        while (resposta == 1)
        {
            Console.WriteLine("Qual é o id do produto?");
            car.ProdutoId = int.Parse(Console.ReadLine());
            car.UsuarioId = UsuarioLogado.id;
          
            Console.WriteLine("Deseja colocar mais algum produto no carrinho?");
            Console.WriteLine("1 -Sim, desejo");
            Console.WriteLine("2 - Não, obrigado(a)");
            resposta = int.Parse(Console.ReadLine());

            if (resposta == 1)
            {
                Carrinho carrinho1 = RealizarCompra();
                _carrinhoUC.ComprarProduto(carrinho1);
                Console.WriteLine($"Produto adicionado ao carrinho com sucesso");
            }
        }

        List<CarrinhoDTO> carrinhoDTOs = _carrinhoUC.ListarCarrinhoPorId(UsuarioLogado);
        foreach (CarrinhoDTO ca in carrinhoDTOs)
        {
            Console.WriteLine(ca.ToString());
            Console.WriteLine($"Produto adicionado ao carrinho com sucesso");
        }
        
          Console.WriteLine("Qual das opções baixo você deseja realizar?");
        Console.WriteLine("1 - Desejo retirar na loja");
        Console.WriteLine("2 - Desejo receber em casa");
        return car;
    }

}

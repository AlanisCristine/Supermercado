using Core._02_Repository;
using Core.Entidades;
using Dapper;
using Dapper.Contrib.Extensions;
using FrontEnd.Models.DTO;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;

namespace TrabalhoFinal._02_Repository;

public class CarrinhoRepository : ICarrinhoRepository
{
    private readonly string ConnectionString;
    private readonly IUsuarioRepository _repositoryUsuario;
    private readonly IProdutoRepository _repositoryProduto;
    public CarrinhoRepository(IConfiguration connectioString, IUsuarioRepository usuarioRepository, IProdutoRepository produtoRepository)
    {
        ConnectionString = connectioString.GetConnectionString("DefaultConnection");
        _repositoryUsuario = usuarioRepository;
        _repositoryProduto = produtoRepository;
    }
    public void Adicionar(Carrinho carrinho)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Insert<Carrinho>(carrinho);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Carrinho carrinho = BuscarPorId(id);
        connection.Delete<Carrinho>(carrinho);
    }
    public void Editar(Carrinho carrinho)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Update<Carrinho>(carrinho);
    }
    public List<Carrinho> Listar()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.GetAll<Carrinho>().ToList();
    }
    public Carrinho BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Carrinho>(id);
    }

    public List<CarrinhoDTO> ListarCarrinhoPreenchido(int usuarioId)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        List<Carrinho> list = connection.Query<Carrinho>($"SELECT Id, UsuarioId, ProdutoId FROM Carrinhos WHERE UsuarioId = {usuarioId}").ToList();
        List<CarrinhoDTO> listDTO = TransformarListaCarrinhoEmCarrinhoDTO(list);
        return listDTO;
    }
       
    
    private List<CarrinhoDTO> TransformarListaCarrinhoEmCarrinhoDTO(List<Carrinho> list)
    {
        List<CarrinhoDTO> listDTO = new List<CarrinhoDTO>();

        foreach (Carrinho car in list)
        {
            CarrinhoDTO Carrinho = new CarrinhoDTO();
            Carrinho.Produto = _repositoryProduto.BuscarPorId(car.ProdutoId);
            Carrinho.Usuario = _repositoryUsuario.BuscarPorId(car.UsuarioId);
            listDTO.Add(Carrinho);
        }
        return listDTO;
    }
}


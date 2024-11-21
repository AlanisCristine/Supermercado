using Core._01_Services.Interfaces;
using Core._02_Repository;
using Core.Entidades;
using FrontEnd.Models.DTO;
using TrabalhoFinal._02_Repository;

namespace TrabalhoFinal._01_Services;

public class CarrinhoService : ICarrinhoService
{
    private readonly ICarrinhoRepository repository;
    public CarrinhoService(ICarrinhoRepository carrinhoRepository)
    {
        repository = carrinhoRepository;
    }

    public void Adicionar(Carrinho carrinho)
    {
        repository.Adicionar(carrinho);
    }

    public void Remover(int id)
    {
        repository.Remover(id);
    }
    public List<CarrinhoDTO> ListarCarrinhoPreenchido(int usuarioId)
    {
        return repository.ListarCarrinhoPreenchido(usuarioId);
    }

    
    public List<Carrinho> Listar()
    {
        return repository.Listar();
    }
    public Carrinho BuscarTimePorId(int id)
    {
        return repository.BuscarPorId(id);
    }
    public void Editar(Carrinho editPessoa)
    {
        repository.Editar(editPessoa);
    }
}

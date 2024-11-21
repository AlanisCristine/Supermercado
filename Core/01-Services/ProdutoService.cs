using Core._01_Services.Interfaces;
using Core._02_Repository;
using Core.Entidades;
using TrabalhoFinal._02_Repository;

namespace TrabalhoFinal._01_Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository repository;
    public ProdutoService(IProdutoRepository produtoRepository)
    {
        repository = produtoRepository;
    }
    public void Adicionar(Produto produto)
    {
        repository.Adicionar(produto);
    }

    public void Remover(int id)
    {
        repository.Remover(id);
    }

    public List<Produto> Listar()
    {
        return repository.Listar();
    }
    public Produto BuscarTimePorId(int id)
    {
        return repository.BuscarPorId(id);
    }
    public void Editar(Produto editPessoa)
    {
        repository.Editar(editPessoa);
    }
}

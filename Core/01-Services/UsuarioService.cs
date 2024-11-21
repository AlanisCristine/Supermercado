using Core._01_Services.Interfaces;
using Core._02_Repository;
using Core._03_Entidades.DTO;
using Core.Entidades;
using TrabalhoFinal._02_Repository;

namespace TrabalhoFinal._01_Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository repository;
    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        repository = usuarioRepository;
    }
    public void Adicionar(Usuario usuario)
    {
        repository.Adicionar(usuario);
    }

    public Usuario FazerLogin(UsuarioLoginDTO usuarioLoginDTO)
    {
        List<Usuario> listarusuario = Listar();
        foreach(Usuario usuario in listarusuario)
        {
            if(usuario.Username == usuarioLoginDTO.Username && usuario.Senha == usuarioLoginDTO.Senha)
            {
                return usuario;
            }
        }
        return null;
    }

    public void Remover(int id)
    {
        repository.Remover(id);
    }

    public List<Usuario> Listar()
    {
        return repository.Listar();
    }
    public Usuario BuscarTimePorId(int id)
    {
        return repository.BuscarPorId(id);
    }
    public void Editar(Usuario editPessoa)
    {
        repository.Editar(editPessoa);
    }
}

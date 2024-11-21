using Core._03_Entidades.DTO;
using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interfaces
{
    public interface IUsuarioService
    {
        void Adicionar(Usuario usuario);
        Usuario FazerLogin(UsuarioLoginDTO usuarioLoginDTO);
        void Remover(int id);
        List<Usuario> Listar();
        Usuario BuscarTimePorId(int id);
        void Editar(Usuario editPessoa);
    }
}

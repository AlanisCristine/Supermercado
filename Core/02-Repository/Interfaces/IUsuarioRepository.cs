using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Remover(int id);
        void Editar(Usuario usuario);
        List<Usuario> Listar();
        Usuario BuscarPorId(int id);
    }
}

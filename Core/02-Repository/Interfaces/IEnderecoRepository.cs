using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository
{
    public interface IEnderecoRepository
    {
        void Adicionar(Endereco endereco);
        void Remover(int id);
        List<Endereco> ListarEnderecoPorId(int usuarioId);
        void Editar(Endereco endereco);
        List<Endereco> Listar();
        Endereco BuscarPorId(int id);
    }
}

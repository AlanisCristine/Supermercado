using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interfaces
{
    public interface IEnderecoService
    {
        void Adicionar(Endereco endereco);
        void Remover(int id);
        List<Endereco> Listar();
        List<Endereco> ListarEnderecoPorId(int usuarioId);
        Endereco BuscarTimePorId(int id);
        void Editar(Endereco editEndereco);
    }
}

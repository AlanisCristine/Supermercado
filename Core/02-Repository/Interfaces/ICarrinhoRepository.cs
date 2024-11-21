using Core.Entidades;
using FrontEnd.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository
{
    public interface ICarrinhoRepository
    {
        void Adicionar(Carrinho carrinho);
        void Remover(int id);
        void Editar(Carrinho carrinho);
        List<Carrinho> Listar();
        Carrinho BuscarPorId(int id);
        List<CarrinhoDTO> ListarCarrinhoPreenchido(int usuarioId);
    }
}

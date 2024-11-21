using Core.Entidades;
using FrontEnd.Models.DTO;

namespace Core._01_Services.Interfaces
{
    public interface ICarrinhoService
    {


        void Adicionar(Carrinho carrinho);
        void Remover(int id);
        List<CarrinhoDTO> ListarCarrinhoPreenchido(int usuarioId);
        List<Carrinho> Listar();
        Carrinho BuscarTimePorId(int id);
        void Editar(Carrinho editPessoa);
    }
}

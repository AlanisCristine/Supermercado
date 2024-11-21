using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interfaces
{
    public interface IVendaService
    {
        void Adicionar(Venda venda);
        void Remover(int id);
        List<Venda> Listar();
        Venda BuscarTimePorId(int id);
        void Editar(Venda editPessoa);
    }
}

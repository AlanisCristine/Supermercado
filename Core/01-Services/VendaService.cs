using Core._01_Services.Interfaces;
using Core._02_Repository;
using Core._03_Entidades;
using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository;

namespace Core._01_Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository repository;
        public VendaService(IVendaRepository vendaRepository)
        {
            repository = vendaRepository;
        }
        public void Adicionar(Venda venda)
        {
            repository.Adicionar(venda);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Venda> Listar()
        {
            return repository.Listar();
        }
        public Venda BuscarTimePorId(int id)
        {
            return repository.BuscarPorId(id);
        }
        public void Editar(Venda editPessoa)
        {
            repository.Editar(editPessoa);
        }
    }
}

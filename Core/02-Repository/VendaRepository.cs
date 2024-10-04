using Core._03_Entidades;
using Core.Entidades;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository
{
    public class VendaRepository
    {
        private readonly string ConnectionString;
        public VendaRepository(string connectioString)
        {
            ConnectionString = connectioString;
        }
        public void Adicionar(Venda venda)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Venda>(venda);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Venda venda = BuscarPorId(id);
            connection.Delete<Venda>(venda);
        }
        public void Editar(Venda venda)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Venda>(venda);
        }
        public List<Venda> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Venda>().ToList();
        }
        public Venda BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Venda>(id);
        }

    }
}

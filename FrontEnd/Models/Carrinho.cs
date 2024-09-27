using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Models;

public class Carrinho
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int ProdutoId { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Models.DTO
{
    public class ReadCarrinhoDTO
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public Usuario Usuario { get; set; }

    }
}

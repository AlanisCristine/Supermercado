using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string username { get; set; }
        public string senha { get; set; }
        public string email { get; set; }

        public override string ToString()
        {
            return $"Id: {id} - Nome: {nome} - Email: {email} - Senha  {senha}";
        }

    }
}

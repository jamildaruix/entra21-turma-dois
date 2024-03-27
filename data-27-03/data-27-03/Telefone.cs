using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_27_03
{
    public class Telefone
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int IdPessoa { get; set; }

        public Provedor? Provedor { get; set; }
    }
}

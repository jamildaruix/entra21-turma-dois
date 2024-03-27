using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_27_03
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte Idade { get; set; }
        public DateTime Cadastro { get; set; }
        public bool Ativo { get; set; }

        public List<Telefone> Telefones { get; set; }
    }
}

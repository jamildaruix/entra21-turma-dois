// See https://aka.ms/new-console-template for more information
using data_27_03;

List<Pessoa> pessoas =
[
    new Pessoa { Id = 10, Nome = "ID PESSOA 10", Idade = 54, Cadastro = new DateTime(2004, 05, 21), Ativo = true },
    new Pessoa { Id = 3, Nome = "ID PESSOA 3", Idade = 18, Cadastro = new DateTime(2000, 12, 01), Ativo = true },
    new Pessoa { Id = 99, Nome = "ID PESSOA 99", Idade = 31, Cadastro = new DateTime(2004, 05, 21), Ativo = false },
    new Pessoa { Id = 1500, Nome = "ID PESSOA 1500", Idade = 15, Cadastro = new DateTime(2000, 05, 30), Ativo = true },
    new Pessoa { Id = 171, Nome = "ID PESSOA 171", Idade = 14, Cadastro = new DateTime(2003, 01, 31), Ativo = false },
    new Pessoa { Id = 75, Nome = "ID PESSOA 75", Idade = 54, Cadastro = new DateTime(2014, 8, 10), Ativo = true },
];

foreach (var pessoa in pessoas.Where(w => w.Id == 10))
{
    pessoa.Telefones =
    [
        new Telefone { Id = 1, IdPessoa = 10, Numero = 12345678, Provedor = new() { Id = 1, Descricao = "Provedor A" } },
        new Telefone { Id = 2, IdPessoa = 10, Numero = 77889955, Provedor = new() { Id = 2, Descricao = "Provedor B" } },
        new Telefone { Id = 3, IdPessoa = 10, Numero = 99887711, Provedor = new() { Id = 3, Descricao = "Provedor C" } }
    ];
}


List<Telefone> telefones = new List<Telefone>();
telefones.Add(new Telefone { Id = 1, IdPessoa = 10, Numero = 12345678 });
telefones.Add(new Telefone { Id = 2, IdPessoa = 10, Numero = 77889955 });
telefones.Add(new Telefone { Id = 3, IdPessoa = 10, Numero = 99887711 });
telefones.Add(new Telefone { Id = 4, IdPessoa = 171, Numero = 96687547 });
telefones.Add(new Telefone { Id = 5, IdPessoa = 3, Numero = 66554411 });

Pessoa? exemploFind = pessoas.Find(f => f.Idade == 54);

if (exemploFind == null)
{
    Console.WriteLine("Dados não encontrado !");
}

Console.WriteLine($"Teste Find {exemploFind!.Id}");

List<Pessoa>? pessoasEncontradas54Anos = pessoas.Where(w => w.Idade == 54).ToList();

List<Pessoa>? pessoasEncontradas54Anos2 = (from p in pessoas
                                           where p.Idade == 54
                                           select p).ToList();

Console.WriteLine("Expression Lambda");

List<byte>? pessoasEncontradas54AnosGroupBy = pessoas.GroupBy(g => g.Idade)
                                                     .OrderBy(o => o.Key)
                                                     .Select(s => s.Key)
                                                     .ToList();

List<byte>? pessoasEncontradas54AnosGroupBy2 = (from p in pessoas
                                                group p by p.Idade into grupoIdade
                                                orderby grupoIdade.Key
                                                select grupoIdade.Key).ToList();

Console.WriteLine("Group by");


dynamic teste = new { Id = 10, Campo2 = "Jamil" };

var exemploJoin01 = telefones.Join(pessoas,
                                   telJoin => telJoin.IdPessoa,
                                   pessoalJoin => pessoalJoin.Id,
                                   (tel, pessoa) => new { Tel = tel, Pessoa = pessoa })
                             .ToList();

foreach (var item in exemploJoin01)
{
    Console.WriteLine($"Lista Pessoa com o Id {item.Pessoa.Id}");
    Console.WriteLine($"Lista Telefones com o Id Pessoa {item.Tel.IdPessoa}");
}


var exemploJoin02 = (from t in telefones
                     join p in pessoas on t.IdPessoa equals p.Id
                     select new { Tel = t, Pessoa = p })
                    .ToList();

foreach (var item in exemploJoin02)
{
    Console.WriteLine($"Lista Pessoa com o Id {item.Pessoa.Id}");
    Console.WriteLine($"Lista Telefones com o Id Pessoa {item.Tel.IdPessoa}");
}

//SELECT *
//FROM TELEFONE
//INNER JOIN PESSOAS
//ON TELEFONE.IdPessoa = Pessoa.Id

Console.WriteLine("Join");

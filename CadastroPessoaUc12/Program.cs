using CadastroPessoaUc12.Classes;

Console.Clear();
Console.WriteLine(@$"
=============================================
|    Bem vindo ao sistema de cadastro de    | 
|        Pessoas Físicas e Juridícas.       |
=============================================
");

Utils.BarraCarregamento("Iniciando", 100, 40);

List<PessoaFisica> listaPf = new List<PessoaFisica>();

string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
=============================================
|        Escolha uma das opções abaixo:     |
|-------------------------------------------|   
|           1 - Pessoa Física               |
|           2 - Pessoa Juridíca             |
|                                           |
|           0 - Sair                        |
=============================================
");

 opcao = Console.ReadLine();

switch (opcao)
{
    case "1":
            string? opcaoPf;

            do
    {

    Console.Clear();
    Console.WriteLine(@$"
=============================================
|        Escolha uma das opções abaixo:     |
|-------------------------------------------|   
|            1 - Cadastrar Pessoa Física    |
|            2 - Listar Pessoa Física       |
|                                           |
|            0 - Sair                       |
=============================================
");
        opcaoPf = Console.ReadLine();
        fPessoaFisica metodosPf = new PessoaFisica();
        
        switch (opcaoPf)
        {
            case "1":
                PessoaFisica novaPf =new PessoaFisica();
                Endereco novoEndPf = new Endereco();

                Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar:");
                novaPf.Nome = Console.ReadLine();
    
                bool dataValida;
                        do
                        {
                            Console.WriteLine($"Digite a data de nascimento Ex: DD/MM/AAAA");
                            string? dataNascimento = Console.ReadLine();

                            dataValida = metodosPf.ValidarDataNasc(dataNascimento);

                            if (dataValida)
                            {
                                DateTime DataConvertida;
                                DateTime.TryParse(dataNascimento, out DataConvertida);

                                novaPf.dataNasc = DataConvertida;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data digitada inválida, por favor digite uma data válida");
                                Console.ResetColor();
                                Thread.Sleep(3000);

                            }

                        } while (dataValida == false);

                        Console.WriteLine($"Digite o número do CPF"); 
                        novaPf.Cpf = Console.ReadLine();
                        
                        Console.WriteLine($"Digite o rendimento mensal (DIGITE SOMENTE NUMEROS)");
                        novaPf.Rendimento = float.Parse(Console.ReadLine());
                        
                        Console.WriteLine($"Digite o logradouro");
                        novoEndPf.Logradouro = Console.ReadLine();
                        
                        Console.WriteLine($"Digite o numero");
                        novoEndPf.numero = int.Parse(Console.ReadLine());
                        
                        Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio)");
                        novoEndPf.complemento = Console.ReadLine();
                        
                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endCom = Console.ReadLine().ToUpper();

                        if (endCom == "S")
                        {
                            novoEndPf.endComercial = true;
                        }
                        else
                        {
                            novoEndPf.endComercial = false;
                        }
                        novaPf.Endereco = novoEndPf;

                        listaPf.Add(novaPf);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro realizado com sucesso!");
                        Console.ResetColor();
                        Thread.Sleep(3000);

                        break;
                
            case "2":

                        Console.Clear();

                        if (listaPf.Count > 0 )
                        {
                            foreach (PessoaFisica cadaPessoa in listaPf)
                            {
                                Console.Clear();
                                 Console.WriteLine(@$"                                                             
Nome: {cadaPessoa.Nome}
Endereço: {cadaPessoa.Endereco.Logradouro}, {cadaPessoa.Endereco.numero}
Imposto a ser pago: {metodosPf.PagarImposto(cadaPessoa.Rendimento).ToString("C")}
");

                                Console.WriteLine($"Aperte 'ENTER' para continuar");
                                Console.ReadLine();
                            
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Lista vazia");
                            Thread.Sleep(3000);

                        }


                        break;

            case "0":
                break;

            default:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Opção Inválida, por favor digite uma opção válida.");
                Console.ResetColor();
                Thread.Sleep(3000);

                break;
        }
        

    } while (opcaoPf != "0");

    //condicao ? "Sim" : "Não"

    // exemplo de concatenação e interpolação
    // Console.WriteLine($"Nome: {novaPf.Nome} nome: {novaPf.Nome}");
    // Console.WriteLine("Nome: " + novaPf.Nome + "Nome: " + novaPf.Nome);

      
        break;

    case "2":
    PessoaJuridica novaPj = new PessoaJuridica();
    PessoaJuridica metodosPj = new PessoaJuridica();
    Endereco novoEndPj = new Endereco();

    novaPj.Nome = "Nome Pj";
    novaPj.RazaoSocial = "Razão Social Pj";
    novaPj.Cnpj = "00.000.000/0001-00";
    novaPj.Rendimento = 12000.5f;

    novoEndPj.Logradouro = "5th Avenue Park";
    novoEndPj.numero = 1485;
    novoEndPj.complemento = "5th on the Park";
    novoEndPj.endComercial = true;

    novaPj.Endereco = novoEndPj;

    Console.Clear();
    Console.WriteLine(@$"
Nome: {novaPj.Nome}
Razão Social: {novaPj.RazaoSocial}
CNPJ: {novaPj.Cnpj}, Válido: {(metodosPj.ValidarCnpj(novaPj.Cnpj) ? "Sim" : "Não")}
Endereço: {novaPj.Endereco.Logradouro}, N°: {novaPj.Endereco.numero}
Complemento: {novaPj.Endereco.complemento}
");

    Console.WriteLine($"Aperte ENTER para continuar");
    Console.ReadLine();
    
        break;

    case "0":
    Console.Clear();
    Console.WriteLine($"Obrigado por utilizar nosso sistema!");
    Thread.Sleep(3000);

    Utils.BarraCarregamento("Finalizando", 500, 6);

    
        break;

    default:
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine($"Opção Inválida, por favor digite uma opção válida.");
    Console.ResetColor();
    Thread.Sleep(3000);
    
        break;
}

} while (opcao != "0");

// static void BarraCarregamento(string texto, int tempo, int quantidade)
// {
//     Console.BackgroundColor = ConsoleColor.DarkBlue;
//     Console.ForegroundColor = ConsoleColor.DarkMagenta;

//     Console.Write(texto);

//     for (var contador = 0; contador < quantidade; contador++)
//     {
//      Console.Write(".");
//      Thread.Sleep(tempo); 
//     }
//    Console.ResetColor();
// }



using HelpPrests.Classes;
using HelpPrests.Enum;
using System;
using System.Collections;
using System.Collections.Generic;

namespace HelpPrests
{
    class Program
    {
        static int opcaoMenuPrin;
        static int opcaoMenuSec;

        
        //popular Categoria, Serviços e Clientes p/ não precisar cadastrar a cada execução.
        static List<Cliente> listaClientes = new List<Cliente>();
        static List<Categoria> listaCategorias = new List<Categoria>();
        static List<Servico> listaServicos = new List<Servico>();
        static List<Agendamento> listaAgendamentos = new List<Agendamento>();

        static void Main(string[] args)
        {
            PopulaTabelas();

            MenuPrincipal();

            Console.WriteLine("Programa encerrado.");
            Console.ReadLine();
        }

        private static void MenuPrincipal()
        {
            //TELA DO MENU PRINCIPAL
            Console.WriteLine();
            Console.WriteLine("*************************");
            Console.WriteLine("**H E L P   P R E S T S**");
            Console.WriteLine("*************************");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Clientes");
            Console.WriteLine("2 - Serviços");
            Console.WriteLine("3 - Agendamentos");
            Console.WriteLine("4 - Sair");
            Console.WriteLine();

            
            opcaoMenuPrin = int.Parse(Console.ReadLine());
            Console.WriteLine();

            //OPCOES MENU PRINCIPAL
            while (opcaoMenuPrin != 4)
            {
                switch (opcaoMenuPrin)
                {
                    case 1:
                        MenuSecundario("*****C L I E N T E S*****");
                        break;
                    case 2:
                        MenuSecundario("*****S E R V I Ç O S*****");
                        break;
                    case 3:
                        MenuSecundario("*A G E N D A M E N T O S*");
                        break;
                    default:
                        Console.WriteLine("Opção Invalida");
                        break;
                }
                MenuPrincipal();
            }
            Console.Clear();
        }
        private static void MenuSecundario(string titulo)
        {
            //TELA DO MENU SECUNDÁRIO
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("*************************");
            Console.WriteLine(titulo);
            Console.WriteLine("*************************");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Incluir");

            if (opcaoMenuPrin == 3)
            {
                Console.WriteLine("2 - Atender Agend.");
                Console.WriteLine("3 - Desmarcar Agend.");
            }
            else
            {
                Console.WriteLine("2 - Alterar");
                Console.WriteLine("3 - Excluir");
            }
            Console.WriteLine("4 - Listar");
            Console.WriteLine("5 - Retornar ao menu Principal");
            Console.WriteLine();

            opcaoMenuSec = int.Parse(Console.ReadLine());
            Console.WriteLine();

            //OPCOES MENU SECUNDÁRIO
            while (opcaoMenuSec != 5)
            {
                switch (opcaoMenuSec)
                {
                    case 1:  
                        Incluir(opcaoMenuPrin);
                        Console.ReadLine();
                        opcaoMenuSec = 5;
                        break;
                    case 2:
                        AlterarAtender(opcaoMenuPrin);
                        Console.ReadLine();
                        opcaoMenuSec = 5;
                        break;
                    case 3:
                        ExcluirDesmarcar(opcaoMenuPrin);
                        Console.ReadLine();
                        opcaoMenuSec = 5;
                        break;
                    case 4:
                        Listar(opcaoMenuPrin);
                        Console.ReadLine();
                        opcaoMenuSec = 5;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida");
                        break;
                }
            }
            Console.Clear();
        }
        private static void PopulaTabelas()
        {
            Cliente c1 = 
                new Cliente(1, "Tati", new DateTime(2018, 9, 25), "02717390022", "avenida", 1992, "93260064", "Centro", "Esteio", "RS");
            Cliente c2 = 
                new Cliente(2, "Jeh", new DateTime(2018, 9, 20), "02732937029", "rua", 305, "93260333", "Centro", "São Leopoldo", "RS");
            Cliente c3 = 
                new Cliente(3, "Inara", new DateTime(2018, 9, 15), "60252308034", "Travessa", 444, "933939393", "Centro", "Canoas", "RS");
            listaClientes.Add(c1);
            listaClientes.Add(c2);
            listaClientes.Add(c3);

            Categoria cat1 = new Categoria(1, "Serviços Hidraúlicos");
            Categoria cat2 = new Categoria(2, "Informática");
            Categoria cat3 = new Categoria(3, "Salão de Beleza");
            listaCategorias.Add(cat1);
            listaCategorias.Add(cat2);
            listaCategorias.Add(cat3);

            Servico s1 = new Servico(1, "Troca de Torneira", cat1);
            Servico s2 = new Servico(2, "Formatação de Computador", cat2);
            Servico s3 = new Servico(3, "Manicure", cat3);
            listaServicos.Add(s1);
            listaServicos.Add(s2);
            listaServicos.Add(s3);            
        }

        
        //LISTAGEM
        private static void Listar(int opcaoMenu)
        {           
            switch (opcaoMenu)
            {
                case 1:
                    ListarClientes();
                    break;
                case 2:
                    ListarServicos();
                    break;
                case 3:
                    ListarAgendamentos();
                    break;
            }
        }

        private static void ListarClientes()
        {
            
            if (listaClientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            Console.WriteLine("LISTAGEM DE CLIENTES");
            for (int i = 0; i < listaClientes.Count; i++)
            {
                Cliente cliente = listaClientes[i];
                Console.WriteLine("Cliente #{0}", i+1);
                Console.WriteLine(cliente.ToString());
            }
        }

        private static void ListarAgendamentos()
        {

            if (listaAgendamentos.Count == 0)
            {
                Console.WriteLine("Nenhum agendamento cadastrado.");
                return;
            }

            Console.WriteLine("LISTAGEM DE AGENDAMENTOS");
            for (int i = 0; i < listaAgendamentos.Count; i++)
            {
                Agendamento agendamento = listaAgendamentos[i];
                Console.WriteLine("Agendamento #{0}", i + 1);
                Console.WriteLine(agendamento.ToString());
            }
        }

        private static void ListarServicos()
        {

            if (listaServicos.Count == 0)
            {
                Console.WriteLine("Nenhum serviço cadastrado.");
                return;
            }

            Console.WriteLine("LISTAGEM DE SERVIÇOS");
            for (int i = 0; i < listaServicos.Count; i++)
            {
                Servico servico = listaServicos[i];
                Console.Write("#{0} ", i+1);
                Console.WriteLine(servico.ToString());
            }
        }

        private static void ListarCategorias()
        {

            if (listaCategorias.Count == 0)
            {
                Console.WriteLine("Nenhuma categoria cadastrada.");
                return;
            }

            Console.WriteLine("LISTAGEM DE CATEGORIAS");
            for (int i = 0; i < listaCategorias.Count; i++)
            {
                Categoria categoria = listaCategorias[i];
                Console.Write("#{0} ", i+1);
                Console.WriteLine(categoria.ToString());
            }
        }


        //INCLUSOES
        private static void Incluir(int opcaoMenu)
        {
            switch (opcaoMenu)
            {
                case 1:
                    IncluirClientes();
                    break;
                case 2:
                    IncluirServicos();
                    break;
                case 3:
                    IncluirAgendamentos();
                    break;
            }
        }

        private static void IncluirClientes()
        {
            Console.Clear();
            bool cpfExistente = true;
            string cpf = "";

            Cliente cliente = new Cliente();
            
            do
            {
                Console.WriteLine("Inserir novo Cliente");
                Console.Write("Digite o CPF do Cliente:");
                cpf = Console.ReadLine();


                //INFORMOU CPF EXISTENTE
                if (cliente.LocalizaCliente(listaClientes, cpf) != null)
                {
                    Console.WriteLine("Já existe cliente com CPF informado.");
                    return;
                }
                cpfExistente = false;
            } while (cpfExistente);

            Console.Write("Digite o Nome do Cliente:");
            string nome = Console.ReadLine();
            
            Console.Write("Digite a Data de Nasc (dd/mm/yyyy):");
            DateTime dtNasc = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite o Endereço:");
            string endereco = Console.ReadLine();
            
            Console.Write("Digite o Número:");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Digite o CEP:");
            string cep = Console.ReadLine();
            
            Console.Write("Digite o Bairro:");
            string bairro = Console.ReadLine();

            Console.Write("Digite a Cidade:");
            string cidade = Console.ReadLine();

            Console.Write("Digite a UF:");
            string uf = Console.ReadLine();

            cliente = new Cliente(999, nome, new DateTime(dtNasc.Year, dtNasc.Month, dtNasc.Day), cpf, endereco,                         numero, cep, bairro, cidade, uf);
            listaClientes.Add(cliente);

            Console.WriteLine("Cliente incluído com sucesso!!!!!! <<Tecle ENTER>>"); 
        }

        private static void IncluirServicos()
        {   
            Console.Clear();
            bool servicoExistente = true;
            string descricao;
            Servico servico = new Servico();
            Categoria categoria = new Categoria();

            Console.WriteLine("Inserir novo Serviço");
            do
            {
                Console.Write("Digite a descrição:");
                descricao = Console.ReadLine();

                //INFORMOU CATEGORIA NAO EXISTENTE
                if (servico.LocalizaServico(listaServicos, 0, descricao) != null)
                {
                    Console.WriteLine("Serviço informado já está cadastrado.");
                    return;
                }
                else
                    servicoExistente = false;
            }
            while (servicoExistente);

            int codCat = 0;
            do
            {
                Console.Write("Digite o número da Categoria ou 0 para Listar Todas:");
                codCat = int.Parse(Console.ReadLine());

                if (codCat == 0)
                    ListarCategorias();
                else
                {

                    //INFORMOU CATEGORIA NAO EXISTENTE
                    if (categoria.LocalizaCategoria(listaCategorias, codCat) == null)
                    {
                        Console.WriteLine("Categoria informada nao localizada. <<Tecle ENTER>>");
                        codCat = 0;
                        return;
                    }

                    categoria = categoria.LocalizaCategoria(listaCategorias, codCat);
                }
            } while (codCat == 0);


            servico = new Servico(999, descricao, categoria);
            listaServicos.Add(servico);

            Console.WriteLine("Serviço incluído com sucesso!!!!!! <<Tecle ENTER>>");
        }

        private static void IncluirAgendamentos()
        {   
            
            Console.Clear();

            Console.WriteLine("Inserir novo Agendamento"); ;
            Console.Write("Digite a Data:(dd/mm/yyyy)");
            DateTime dataAgend = DateTime.Parse(Console.ReadLine());

            
            string cpfCli = "";
            int codServ = 0;
            Cliente cliente = new Cliente();
            Servico servico = new Servico();

            //CLIENTE VALIDO
            do
            {
                Console.Write("Digite o CPF do Cliente ou ENTER para Listar Todos:");
                cpfCli = Console.ReadLine();

                if (cpfCli.Equals(""))
                    ListarClientes();
                else
                {
                    //INFORMOU CPF NÃO EXISTENTE
                    if (cliente.LocalizaCliente(listaClientes, cpfCli) == null)
                    {
                        Console.WriteLine("Não foi localizado cliente com CPF informado. <<Tecle ENTER>>");
                        return;
                    }
                    cliente = cliente.LocalizaCliente(listaClientes, cpfCli);
                }
            } while(cpfCli.Equals(""));



            //SERVIÇO VALIDO
            do
            {
                Console.Write("Digite o Número do Serviço ou 0 para Listar Todos:");
                codServ = int.Parse(Console.ReadLine());

                if (codServ == 0)
                    ListarServicos();
                else
                {
                    //INFORMOU SERVIÇO NÃO EXISTENTE
                    if (servico.LocalizaServico(listaServicos, codServ, "") == null)
                    {
                        Console.WriteLine("Não foi localizado serviço com número informado. <<Tecle ENTER>>");
                        return;
                    }

                    servico = servico.LocalizaServico(listaServicos, codServ, "");
                }
            } while (codServ == 0);



            Agendamento agendamento = new Agendamento();

            if (agendamento.ExisteAgendamento(listaAgendamentos, new DateTime(dataAgend.Year, dataAgend.Month, dataAgend.Day), cliente, servico) != null){
                Console.WriteLine("Já existe um agendamento para esta Data, Cliente e Serviço. <<Tecle ENTER>>");
                return;
            }

            agendamento = new Agendamento(999, new DateTime(dataAgend.Year, dataAgend.Month, dataAgend.Day), cliente,                             servico, StatusAgendamento.Agendado);

            listaAgendamentos.Add(agendamento);
            Console.WriteLine("Agendamento incluído com sucesso!!!!! <<Tecle ENTER>>");
        }


        //EXCLUSOES
        private static void ExcluirDesmarcar(int opcaoMenu)
        {
            switch (opcaoMenu)
            {
                case 1:
                    ExcluirClientes();
                    break;
                case 2:
                    ExcluirServicos();
                    break;
                case 3:
                    AtenderDesmarcarAgendamentos("Desmarcar");
                    break;
            }
        }

        private static void ExcluirClientes()
        {
            Console.Clear();
            bool cpfExistente = false;
            string cpf = "";
            Agendamento agendamento = new Agendamento();

            Cliente cliente = new Cliente();

            do
            {
                Console.WriteLine("Excluir Cliente");
                Console.Write("Digite o CPF do Cliente:");
                cpf = Console.ReadLine();


                //INFORMOU CPF EXISTENTE
                if (cliente.LocalizaCliente(listaClientes, cpf) == null)
                {
                    Console.WriteLine("Não existe cliente com CPF informado.");
                    return;
                }
                
                cliente = cliente.LocalizaCliente(listaClientes, cpf);
                cpfExistente = true;
            } while (!cpfExistente);

            if (agendamento.ExisteAgendamento(listaAgendamentos, null, cliente, null) != null)
            {
                Console.WriteLine("Existe agendamento com esse cliente. Exclusão cliente negada.");
                return;
            }


            listaClientes.Remove(cliente);

            Console.WriteLine("Cliente excluído com sucesso!!!!!! <<Tecle ENTER>>");
        }

        private static void ExcluirServicos()
        {
            Console.Clear();
            bool servicoExistente = false;
            string descricao;
            Servico servico = new Servico();
            Categoria categoria = new Categoria();
            Agendamento agendamento = new Agendamento();

            Console.WriteLine("Excluir Serviço");
            do
            {
                Console.Write("Digite a descrição:");
                descricao = Console.ReadLine();

                //INFORMOU CATEGORIA NAO EXISTENTE
                if (servico.LocalizaServico(listaServicos, 0, descricao) == null)
                {
                    Console.WriteLine("Não existe serviço com a descrição informada.");
                    return;
                }

                servico = servico.LocalizaServico(listaServicos, 0, descricao);
                servicoExistente = false;
            }
            while (servicoExistente);


            if (agendamento.ExisteAgendamento(listaAgendamentos, null, null, servico) != null)
            {
                Console.WriteLine("Existe agendamento com esse serviço. Exclusão serviço negada.");
                return;
            }

            listaServicos.Remove(servico);

            Console.WriteLine("Serviço excluído com sucesso!!!!!! <<Tecle ENTER>>");
        }


        //ALTERACOES
        private static void AtenderDesmarcarAgendamentos(string atendDesm)
        {

            Console.Clear();

            if (listaAgendamentos.Count == 0)
            {
                Console.WriteLine("Não existem Agendamentos para Desmarcar/Atender. <<Tecle ENTER>>");
                return;
            }

            Console.WriteLine(atendDesm + "Agendamento:");
            Console.Write("Digite a Data:(dd/mm/yyyy)");
            DateTime dataAgend = DateTime.Parse(Console.ReadLine());


            string cpfCli = "";
            int codServ = 0;
            Cliente cliente = new Cliente();
            Servico servico = new Servico();

            //CLIENTE VALIDO
            do
            {
                Console.Write("Digite o CPF do Cliente ou ENTER para Listar Todos:");
                cpfCli = Console.ReadLine();

                if (cpfCli.Equals(""))
                    ListarClientes();
                else
                {
                    //INFORMOU CPF NÃO EXISTENTE
                    if (cliente.LocalizaCliente(listaClientes, cpfCli) == null)
                    {
                        Console.WriteLine("Não foi localizado cliente com CPF informado. <<Tecle ENTER>>");
                        return;
                    }
                    cliente = cliente.LocalizaCliente(listaClientes, cpfCli);
                }
            } while (cpfCli.Equals(""));



            //SERVIÇO VALIDO
            do
            {
                Console.Write("Digite o Número do Serviço ou 0 para Listar Todos:");
                codServ = int.Parse(Console.ReadLine());

                if (codServ == 0)
                    ListarServicos();
                else
                {
                    //INFORMOU SERVIÇO NÃO EXISTENTE
                    if (servico.LocalizaServico(listaServicos, codServ, "") == null)
                    {
                        Console.WriteLine("Não foi localizado serviço com número informado. <<Tecle ENTER>>");
                        return;
                    }

                    servico = servico.LocalizaServico(listaServicos, codServ, "");
                }
            } while (codServ == 0);



            Agendamento agendamento = new Agendamento();

            if (agendamento.ExisteAgendamento(listaAgendamentos, new DateTime(dataAgend.Year, dataAgend.Month, dataAgend.Day), cliente, servico) == null)
            {
                Console.WriteLine("Agendamento não localizado. <<Tecle ENTER>>");
                return;
            }
            agendamento = agendamento.ExisteAgendamento(listaAgendamentos, new DateTime(dataAgend.Year, dataAgend.Month, dataAgend.Day), cliente, servico);

            if (atendDesm == "Desmarcar")
            {
                agendamento.Desmarcar(listaAgendamentos, agendamento);
                Console.WriteLine("Agendamento desmarcado com sucesso!!!!! <<Tecle ENTER>>");
            }
            else
            {
                agendamento.Atender(listaAgendamentos, agendamento);
                Console.WriteLine("Agendamento atendido com sucesso!!!!! <<Tecle ENTER>>");
            }
        }

        private static void AlterarAtender(int opcaoMenu)
        {
            switch (opcaoMenu)
            {
                case 1:
                    AlterarClientes();
                    break;
                case 2:
                    AlterarServicos();
                    break;
                case 3:
                    AtenderDesmarcarAgendamentos("Atender");
                    break;
            }
        }

        private static void AlterarClientes()
        {
            Console.Clear();
            bool cpfExistente = true;
            string cpf = "";

            Cliente cliente = new Cliente();

            do
            {
                Console.WriteLine("Alterar Cliente");
                Console.Write("Digite o CPF do Cliente:");
                cpf = Console.ReadLine();


                //INFORMOU CPF EXISTENTE
                if (cliente.LocalizaCliente(listaClientes, cpf) == null)
                {
                    Console.WriteLine("Não existe cliente com CPF informado.");
                    return;
                }
                cliente = cliente.LocalizaCliente(listaClientes, cpf);

                listaClientes.Remove(cliente);
                cpfExistente = false;
            } while (cpfExistente);

            Console.Write("Digite o Nome do Cliente:");
            string nome = Console.ReadLine();

            Console.Write("Digite a Data de Nasc (dd/mm/yyyy):");
            DateTime dtNasc = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite o Endereço:");
            string endereco = Console.ReadLine();

            Console.Write("Digite o Número:");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Digite o CEP:");
            string cep = Console.ReadLine();

            Console.Write("Digite o Bairro:");
            string bairro = Console.ReadLine();

            Console.Write("Digite a Cidade:");
            string cidade = Console.ReadLine();

            Console.Write("Digite a UF:");
            string uf = Console.ReadLine();

            cliente = new Cliente(999, nome, new DateTime(dtNasc.Year, dtNasc.Month, dtNasc.Day), cpf, endereco, numero, cep, bairro, cidade, uf);
            listaClientes.Add(cliente);

            Console.WriteLine("Cliente alterado com sucesso!!!!!! <<Tecle ENTER>>");
        }

        private static void AlterarServicos()
        {
            Console.Clear();
            bool servicoExistente = true;
            string descricao;
            string descricaoNova;
            Servico servico = new Servico();
            Categoria categoria = new Categoria();

            Console.WriteLine("Alterar Serviço");
            do
            {
                Console.Write("Digite a descrição atual:");
                descricao = Console.ReadLine();

                //INFORMOU CATEGORIA NAO EXISTENTE
                if (servico.LocalizaServico(listaServicos, 0, descricao) == null)
                {
                    Console.WriteLine("Não existe serviço com a descrição informada.");
                    return;
                }

                Console.Write("Digite a Nova descrição:");
                descricaoNova = Console.ReadLine();

                servico = servico.LocalizaServico(listaServicos, 0, descricao);
                servicoExistente = false;
            }
            while (servicoExistente);

            int codCat = 0;
            do
            {
                Console.Write("Digite o número da Categoria ou 0 para Listar Todas:");
                codCat = int.Parse(Console.ReadLine());

                if (codCat == 0)
                    ListarCategorias();
                else
                {

                    //INFORMOU CATEGORIA NAO EXISTENTE
                    if (categoria.LocalizaCategoria(listaCategorias, codCat) == null)
                    {
                        Console.WriteLine("Categoria informada nao localizada. <<Tecle ENTER>>");
                        codCat = 0;
                        return;
                    }
                    categoria = categoria.LocalizaCategoria(listaCategorias, codCat);
                }
            } while (codCat == 0);

            listaServicos.Remove(servico);
            servico = new Servico(999, descricaoNova, categoria);
            listaServicos.Add(servico);

            Console.WriteLine("Serviço alterado com sucesso!!!!!! <<Tecle ENTER>>");
        }
    }
}

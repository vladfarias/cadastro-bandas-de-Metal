using appCadastroDio;
using appCadastroDio.Interfaces;

namespace appCadastroDio;

    class Program
    {
        static BandaMetalRepositorio repositorio = new BandaMetalRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {   switch (opcaoUsuario)
                {
                    case "1":
                        ListarBandas();
                        break;

                    case "2":
                        InserirBanda();
                        break;

                    case "3":
                        AtualizarBanda();
                        break;
                    
                    case "4":
                        ExcluirBanda();
                        break;

                    case "5":
                        VisualizarBanda();
                        break;

                    case "C":
                        Console.Clear();
                        break;
                                            
                
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
                 
            }
            Console.WriteLine("🤘🤘Espero vê-lo em breve!🤘🤘");
            Console.ReadLine(); 


        }

        private static void ListarBandas()
        {
            Console.WriteLine("Listar Bandas");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Sem banda cadastrada.");
				return;
            }
            
            foreach (var banda in lista)
            {   
                var excluido = banda.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", banda.retornaId(), banda.retornaNome(), (excluido ? "*Excluída*" : ""));

            }
        }

        private static void InserirBanda()
        {
            Console.WriteLine("Inserir nova banda");

            foreach (int i in Enum.GetValues(typeof(Estilo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Estilo), i));
			}

            Console.Write("Digite o estilo da banda entre as opções acima: ");
			int entradaEstilo = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome da Banda: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o Instagram da Banda: ");
			string entradaInstagram = Console.ReadLine();

			Console.Write("Digite o Estado (UF) de origem da Banda: ");
			string entradaEstado = Console.ReadLine();

            Console.Write("Digite um e-mail de contato: ");
			string entradaContato = Console.ReadLine();

            BandaMetal novaBanda = new BandaMetal(id: repositorio.ProximoId(),
										estilo: (Estilo)entradaEstilo,
										nome: entradaNome,
										instagram: entradaInstagram,
										estado: entradaEstado,
                                        contato: entradaContato);

            repositorio.Insere(novaBanda);

        }

        private static void AtualizarBanda()
        {
            Console.WriteLine();
            Console.WriteLine("Informe o ID da Banda: ");
            int indiceBanda = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Estilo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Estilo), i));
			}

            Console.Write("Digite o estilo da banda entre as opções acima: ");
			int entradaEstilo = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome da Banda: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o Instagram da Banda: ");
			string entradaInstagram = Console.ReadLine();

			Console.Write("Digite o Estado (UF) de origem da Banda: ");
			string entradaEstado = Console.ReadLine();

            Console.Write("Digite um e-mail de contato: ");
			string entradaContato = Console.ReadLine();

            BandaMetal atualizaBanda = new BandaMetal(id: indiceBanda,
										estilo: (Estilo)entradaEstilo,
										nome: entradaNome,
										instagram: entradaInstagram,
										estado: entradaEstado,
                                        contato: entradaContato);

            repositorio.Atualiza(indiceBanda, atualizaBanda);

        }

        private static void ExcluirBanda()
        {
            
            Console.WriteLine();
            Console.WriteLine("Informe o ID da Banda: ");
            int indiceBanda = int.Parse(Console.ReadLine());

            Console.WriteLine($"Tem certeza que deseja excluir o ID {indiceBanda}? S/N ?" + Environment.NewLine);
            string decisao = Console.ReadLine().ToUpper();
            
            if (decisao == "S")
            {
                repositorio.Exclui(indiceBanda);
            }
            else
            {
                return;
            }
            

        }

        private static void VisualizarBanda()
        {
                    
            Console.WriteLine("Informe o ID da Banda: ");
            int indiceBanda = int.Parse(Console.ReadLine());

            var banda = repositorio.RetornaPorID(indiceBanda);
            Console.WriteLine(banda);
                       

        }

            
        private static string ObterOpcaoUsuario()
        {
        Console.WriteLine();
        Console.WriteLine("🤘🤘 Bem-vindo à SELVA METAL BR 🤘🤘!" + Environment.NewLine);
        Console.WriteLine("Informe a opção desejada: " + Environment.NewLine);
        
        Console.WriteLine("1- Listar Bandas");
        Console.WriteLine("2- Inserir nova banda");
        Console.WriteLine("3- Atualizar Banda");
        Console.WriteLine("4- Excluir banda");
        Console.WriteLine("5- Visualizar banda");
        Console.WriteLine("C- Limpar tela");
        Console.WriteLine("X- Sair");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;
        
        }
    }




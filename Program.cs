using System;
//Recursos adicionados: Sugestão Aleatória, Favoritar Série, Desfavoritar Série, Listar Séries Favoritas
namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "6":
						SerieAleatoria();
						break;
					case "7":
						FavoritarSerie();						
						break;
					case "8":
						ListarSeriesFavoritas();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }
        private static void SerieAleatoria()
		{
			Console.WriteLine();
			Console.Write("A nossa sugestão de série pra você hoje é: ");
			Console.WriteLine();
			Console.WriteLine();
			
			var aleatorio = repositorio.Aletoriza();

			Console.WriteLine(aleatorio);
			Console.WriteLine();
			Console.WriteLine();
			
		}

		private static void FavoritarSerie()
		{
			Console.WriteLine();
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Favorita(indiceSerie);
		}

        private static void ExcluirSerie()
		{
			Console.WriteLine();
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.WriteLine();
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
			Console.WriteLine();
			Console.WriteLine();
		}

        private static void AtualizarSerie()
		{
			Console.WriteLine();
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine();
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());
			Console.WriteLine();
			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();
			Console.WriteLine();
			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());
			Console.WriteLine();
			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();
			Console.WriteLine();
			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
			Console.WriteLine();
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
				var favorito = serie.retornaFavorito();
                Console.WriteLine();
				Console.WriteLine("#ID {0}: - {1} {2} {3}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""), (favorito ? "*Favorito*" : ""));
			}
		}

		 private static void ListarSeriesFavoritas()
		{
			int favoritos = 0;
			Console.WriteLine("Séries Favoritas");
			Console.WriteLine();

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
				var favorito = serie.retornaFavorito();
                
				if(favorito == true & excluido == false)
				{
					favoritos = favoritos + 1;
					Console.WriteLine();
					Console.WriteLine("#ID {0}: - {1}  Favorito:{2}", serie.retornaId(), serie.retornaTitulo(), serie.retornaFavorito());
				}	
			}

			if (favoritos == 0)
			{
				Console.WriteLine("Nenhuma série foi favoritada.");
				return;				
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine();
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());
			Console.WriteLine();

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();
			Console.WriteLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());
			Console.WriteLine();

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();
			Console.WriteLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
			Console.WriteLine();
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("6- Sugestão de série aletória");
			Console.WriteLine("7- Favoritar/Desfavoritar série");
			Console.WriteLine("8- Listar séries Favoritas");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}

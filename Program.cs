using System;
using System.Collections.Generic;

namespace ConsoleSeries
{
    class Program
    {
        public static RepositorySerie repository = new RepositorySerie();
        static void Main(string[] args)
        {
            runApp();
        }

        private static void runApp()
        {
            string option;
            do
            {
                option = getUserOption().ToUpper();
                switch (option)
                {
                    case "1":
                        ListSeries();
                    break;
                    case "2":
                        InsertMethod();
                    break;
                    case "3":

                    break;
                    case "4":

                    break;
                    case "5":

                    break;
                    default:
                        option = "X";
                    break;
                }
            } while (option != "X");
        }

        private static void InsertMethod()
        {
            Console.WriteLine("\n\t\t\t\t -#- Cadastro de Série -#-");
            Console.WriteLine("\n\t\tGêneros");
            foreach (var genre in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("# {0} - {1}", (int)genre, (Genre)genre);
            }
            
            try
            {
                Console.Write("\nDigite o gênero da série: ");
                byte serieGenre = byte.Parse(Console.ReadLine());
                Console.Write("Digite o título da série: ");
                string serieTitle = Console.ReadLine();

                Console.Write("Digite o ano de início: ");
                int launchYear = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a descrição da série: ");
                string description = Console.ReadLine();

                Series newSerie = new Series((Genre)serieGenre, serieTitle, description, launchYear);
                repository.Insert(newSerie);    
            }catch(FormatException)
            {
                throw new FormatException("Gênero não existe.");
            }catch(Exception e)
            {
                // throw new ArgumentNullException("Necessário informar o gênero da série");
                Console.WriteLine(e.Message);
            }


        }

        static string getUserOption(){
            Console.WriteLine("\n\t\t\t\tOpções");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("L - Limpar tela");
            Console.WriteLine("X - Sair\n");



            return Console.ReadLine();
        }

        public static void ListSeries()
        {
            Console.WriteLine("\n\t\t\t\t-#- Lista de Séries -#-");
            if(repository.List().Count > 0)
            {
                List<Series> repositoryList = repository.List();
                foreach (var serie in repositoryList)
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.GetId(), serie.GetTitle());
                }   
            }else
            {
                Console.WriteLine("Não existem séries");
            }
            
        }
    }
}

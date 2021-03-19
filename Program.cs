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
                        Console.WriteLine("\n\t\t\t\t-#- Lista de Séries -#-");
                        ListSeries();
                    break;
                    case "2":
                        Console.WriteLine("\n\t\t\t\t -#- Cadastro de Série -#-");
                        InsertSerie();
                    break;
                    case "3":
                        Console.WriteLine("\n\t\t\t\t -#- Atualizar informações -#-");
                        UpdateSerie();
                    break;
                    case "4":
                        Console.WriteLine("\n\t\t\t\t -#- Remover série -#-");
                        DeleteSeries();
                    break;
                    case "5":
                        Console.WriteLine("\n\t\t\t\t -#- Série -#-");
                        ViewSerie();
                    break;
                    default:
                        option = "X";
                    break;
                }
            } while (option != "X");
        }

        private static void ViewSerie()
        {
            ListSeries();
            Console.Write("\nQual série deseja visualizar? ");
            int serieIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("\nInformações:\n");
            Console.WriteLine(repository.GetbyID(serieIndex));
            
        }

        private static void DeleteSeries()
        {
            ListSeries();
            Console.Write("\nQual série deseja deletar? ");
            int serieIndex = int.Parse(Console.ReadLine()) - 1;
            repository.Delete(serieIndex);
            Console.WriteLine("Série deletada.");
        }

        private static void UpdateSerie()
        {
            ListSeries();
            try
            {
                Console.Write("\nEscolha a série a ser atualizada: ");
                int serieIndex = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("\n\t\tGêneros");
                foreach (var genre in Enum.GetValues(typeof(Genre)))
                {
                    Console.WriteLine("# {0} - {1}", (int)genre, (Genre)genre);
                }
                Console.Write("\nDigite o gênero da série: ");
                byte serieGenre = byte.Parse(Console.ReadLine());
                Console.Write("Digite o título da série: ");
                string serieTitle = Console.ReadLine();

                Console.Write("Digite o ano de início: ");
                int launchYear = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a descrição da série: ");
                string description = Console.ReadLine();

                Series updatedSerie = new Series(serieIndex, (Genre)serieGenre, serieTitle, description, launchYear);
                repository.Update(serieIndex, updatedSerie);    
            }catch(FormatException)
            {
                throw new FormatException("Gênero não existe.");
            }catch(Exception e)
            {
                // throw new ArgumentNullException("Necessário informar o gênero da série");
                Console.WriteLine(e.Message);
            }

            
        }

        private static void InsertSerie()
        {
            
            Console.WriteLine("\n\t\tGêneros");
            foreach (var genre in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("# {0} - {1}", (int)genre, (Genre)genre);
            }
            
            try
            {
                Console.Write("\nDigite o gênero da série: ");
                int serieGenre = int.Parse(Console.ReadLine());
                Console.Write("Digite o título da série: ");
                string serieTitle = Console.ReadLine();

                Console.Write("Digite o ano de início: ");
                int launchYear = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a descrição da série: ");
                string description = Console.ReadLine();

                Series newSerie = new Series(1 + repository.NextId(), (Genre)serieGenre, serieTitle, description, launchYear);
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
            if(repository.List().Count > 0)
            {
                List<Series> repositoryList = repository.List();
                Console.WriteLine();
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

using System;

namespace dio_series {
    class Program {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args) {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X") {
                switch (userOption) {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        RemoveSeries();
                        break;
                    case "5":
                        MoreInfoSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Saindo...");
        }

        private static void ListSeries() {
            Console.WriteLine("Listar séries");
            Console.WriteLine("-------------");

            var lista = repository.ListEntities();

            if (lista.Count == 0) {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            bool isActive;
            foreach(var serie in lista) {
                isActive = serie.GetIsActive();
                Console.WriteLine(
                    "#ID {0}: - {1} {2}",
                    serie.GetId(),
                    serie.GetTitle(),
                    !isActive ? "*Excluído*" : ""
                );
            }
        }

        private static int ReadIdSerie() {
            Console.Write("Digite o id da série: ");

            return int.Parse(Console.ReadLine());
        }

        private static Series readSerie(bool isNew) {
            int idSerie;
            if (isNew) {
                idSerie = repository.NextId();
            } else {
                idSerie = ReadIdSerie();
            }


            foreach(int i in Enum.GetValues(typeof(Categories))) {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categories), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int newCategory = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string newTitle = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int newYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string newDesc = Console.ReadLine();

            return new Series(
                id: idSerie,
                category: (Categories)newCategory,
                title: newTitle,
                year: newYear,
                description: newDesc
            );
        }

        private static void InsertSeries() {
            Console.WriteLine("Inserir série");
            Console.WriteLine("-------------");

            bool isNew = true;
            Series newSerie = readSerie(isNew);

            repository.InsertEntity(newSerie);
        }

        private static void UpdateSeries() {
            Console.WriteLine("Atualizar série");
            Console.WriteLine("--------------");

            bool isNew = false;
            Series updatedSerie = readSerie(isNew);         

            repository.UpdateEntity(updatedSerie.GetId(), updatedSerie);
        }

        private static void RemoveSeries() {
            int idSerie = ReadIdSerie();

            repository.RemoveEntity(idSerie);
        }

        private static void MoreInfoSeries() {
            int idSerie = ReadIdSerie();

            Series serie = repository.GetById(idSerie);
            Console.WriteLine(serie);
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Gerenciamento de séries");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}

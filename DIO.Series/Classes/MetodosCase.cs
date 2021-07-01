using System;

namespace DIO.Series
{
    public abstract class MetodosCase
    {   
        static SerieRepositorio repositorio = new SerieRepositorio();
        public static void ListarSeries()
        {     
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();

                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            } 
        }
        static int entradaGenero = 0;
        static string entradaTitulo = string.Empty;
        static int entradaAno = 0;
        static string entradaDescricao = string.Empty;
        
        private static void CaracteristicasSerie()
        {
            Console.Write("Digite o gênero entre as opções acima: ");
            entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            entradaDescricao = Console.ReadLine();
        }
        
        public static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            CaracteristicasSerie();

            Serie novaSerie = new Serie 
            (
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );
            repositorio.Insere(novaSerie);
        }

        public static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            CaracteristicasSerie();

            Serie atualizaSerie = new Serie 
            (
                id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        
        public static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da série que deseja excluir: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine("Deseja realmente excluir a série de ID " + indiceSerie + "? (S/N)");
            string confirma = Console.ReadLine();
            if(confirma == "S")
            {
                repositorio.Exclui(indiceSerie);
            }
            if (confirma == "N")
            {
                Console.WriteLine("A série não foi excluida.");
            }
            else
            {
                Console.WriteLine("Comando inválido.");
            }
        }

        public static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
    }
}
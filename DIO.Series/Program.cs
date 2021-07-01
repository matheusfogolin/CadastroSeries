using System;
namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {         
            string escolhaUsuario = OpcaoUsuario.ObterOpcaoUsuario();

           while(escolhaUsuario.ToUpper() != "X")
            {
                switch(escolhaUsuario)
                {
                    case "1":
                        MetodosCase.ListarSeries();
                        break;
                    case "2":
                        MetodosCase.InserirSerie();
                        break;
                    case "3":
                        MetodosCase.AtualizarSerie();
                        break;
                    case "4":
                        MetodosCase.ExcluirSerie();
                        break;
                    case "5":
                        MetodosCase.VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();                                                                                
                }

            escolhaUsuario = OpcaoUsuario.ObterOpcaoUsuario();    
            }
        }
 
    }        

        }  

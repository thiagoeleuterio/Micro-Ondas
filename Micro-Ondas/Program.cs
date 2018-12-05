using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Micro_Ondas
{
    class Program
    {
        private static ObservableCollection<Produto> lista = Produto.StartProgram();

        static void Main(string[] args)
        {
            Console.Clear();
            MenuPrincipal();
        }

        private static void MenuPrincipal()
        {
            int opcao;
            Console.Clear();
            Console.WriteLine("[1] Aquecer Alimento");
            Console.WriteLine("[2] Programas de aquecimento");
            Console.WriteLine("[3] Cadastrar programa");
            Console.WriteLine("[0] Sair do Programa");
            Console.WriteLine("-------------------------------------");
            Console.Write("Digite uma opção: ");
            opcao = Int32.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    AquecerAlimentos();
                    break;
                case 2:
                    UtilizarProgramas();
                    break;
                case 3:
                    CadastrarPrograma();
                    break;
                default:
                    SairPrograma();
                    break;
            }
            //Console.ReadKey();
            //Console.Clear();
        }

        private static void CadastrarPrograma()
        {
            int num = lista.Count + 1;
            Console.WriteLine();
            Console.WriteLine("Entre o Alimento:");
            Console.Write("Alimento: ");
            string alimento = Console.ReadLine();
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
        power:
            Console.Write("Power: ");
            int power = int.Parse(Console.ReadLine());
            if (power < 1)
            {
                Console.WriteLine("A potência não pode ser 0");
                goto power;
            }
            else
            {
                if (power > 10)
                {
                    Console.WriteLine("A potência não pode ser maior do que 10");
                    goto power;
                }
            }
            tempo:
            Console.Write("Tempo: ");
            int tempo = int.Parse(Console.ReadLine());
            if (tempo > 120)
            {
                Console.WriteLine("O tempo não pode ser maior que 2 minutos");
                goto tempo;
            }
            if (tempo < 1)
            {
                Console.WriteLine("O tempo não pode ser menor que 1 segundo");
                goto tempo;
            }
            Produto novo = new Produto(num.ToString(), alimento, descricao, power, tempo, '.');
            lista.Add(novo);
            Console.WriteLine();
            Console.WriteLine("Novo programa cadastrado!");
            Console.ReadKey();
            MenuPrincipal();
        }

        private static void AquecerAlimentos()
        {
            Console.WriteLine();
            Console.WriteLine("Entre o Alimento:");
            Console.Write("Alimento: ");
            string alimento = Console.ReadLine();
            power:
            Console.Write("Power: ");
            int power = int.Parse(Console.ReadLine());
            if (power < 1)
            {
                Console.WriteLine("A potência não pode ser 0");
                goto power;
            }
            else
            {
                if (power > 10)
                {
                    Console.WriteLine("A potência não pode ser maior do que 10");
                    goto power;
                }
            }
            tempo:
            Console.Write("Tempo: ");
            int tempo = int.Parse(Console.ReadLine());
            if (tempo > 120)
            {
                Console.WriteLine("O tempo não pode ser maior que 2 minutos");
                goto tempo;
            }
            if (tempo < 1)
            {
                Console.WriteLine("O tempo não pode ser menor que 1 segundo");
                goto tempo;
            }
            for (int i = 0; i <= tempo; i++)
            {
                i++;
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.WriteLine();
            Console.WriteLine("Aqueceu!!!");
            Console.ReadKey();
            MenuPrincipal();
        }

        private static void UtilizarProgramas()
        {
            int opcao;
            Console.WriteLine("-------------------------------------");
            foreach (var item in lista)
            {
                Console.WriteLine("["+ item.ID +"] "+ item.Alimento +"");
            }
            Console.WriteLine("[0] Voltar");
            Console.WriteLine("-------------------------------------");
            Console.Write("Digite uma opção: ");
            opcao = Int32.Parse(Console.ReadLine());
            foreach (var op in lista)
            {
                if (opcao.ToString() == op.ID)
                {
                    AquecerAlimentoPrograma(op);
                    break;
                }
            }            
        }
        
        private static void AquecerAlimentoPrograma(Produto p)
        {
            Console.WriteLine();
            Console.WriteLine("Alimento: "+ p.Alimento);
            Console.WriteLine("Descrição: "+ p.Descricao);
            Console.WriteLine("Power: "+ p.Power);
            Console.WriteLine("Tempo: "+ p.Tempo);
            for (int i = 0; i <= p.Tempo; i++)
            {
                i++;
                Console.Write(p.CharHeating);
                Thread.Sleep(100);
            }
            Console.WriteLine();
            Console.WriteLine("Aqueceu!!!");
            Console.ReadKey();
            MenuPrincipal();
        }

        private static void SairPrograma()
        {
            Console.WriteLine();
            Console.WriteLine("Vc saiu do Programa!!! Clique qq tecla para sair...");
        }

    }   
}

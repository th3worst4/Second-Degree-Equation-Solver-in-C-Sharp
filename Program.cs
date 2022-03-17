using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bhaskara
{
    internal class Program
    {
        static double Delta(double a, double b, double c)
        {
            double delta;
            delta = Math.Pow(b, 2) - 4 * a * c;
            return delta;
        }

        unsafe static Tuple<string, string> Roots(double a, double b, double delta)
        {
            string root1, root2;

            if (delta >= 0)
            {
                root1 = Convert.ToString((-b + Math.Sqrt(delta)) / 2 * a);
                root2 = Convert.ToString((-b - Math.Sqrt(delta)) / 2 * a);
                return Tuple.Create(root1, root2);
            }
            else
            {
                double deltasqrt;
                delta *= -1;
                deltasqrt = Math.Sqrt(delta) / 2 * a;
                b = -b / 2 * a;
                root1 = String.Format("{0}+{1}i", b, deltasqrt);
                root2 = String.Format("{0}-{1}i", b, deltasqrt);
                return Tuple.Create(root1, root2);
            }

        }

        static void Main(string[] args)
        {
            Console.Write("Bhaskara em C#\nVr: 1.0.0\nPor: Caio Silva Couto\n\n");
            double a, b, c, delta;
            Tuple<string, string> roots;

            start:
            Console.Write("Insira a: ");
            string input = Console.ReadLine();
            while(!Double.TryParse(input, out a) || a == 0)
            {
                Console.WriteLine("\"a\" não pode ser 0 ou caractére inválido!");
                Console.WriteLine("Digite a novamente:");
                input = Console.ReadLine();
            }

            Console.Write("Insira b: ");
            input = Console.ReadLine();
            while (!Double.TryParse(input, out b))
            {
                Console.WriteLine("\"b\" não pode ser caractére inválido!");
                Console.WriteLine("Digite b novamente:");
                input = Console.ReadLine();
            }

            Console.Write("Insira c: ");
            input = Console.ReadLine();
            while (!Double.TryParse(input, out c))
            {
                Console.WriteLine("\"c\" não pode ser caractére inválido!");
                Console.WriteLine("Digite c novamente:");
                input = Console.ReadLine();
            }

            delta = Delta(a, b, c);
            Console.WriteLine("O delta é: " + delta);


            roots = Roots(a, b, delta);
            Console.WriteLine("As raízes são: {0} e {1}", roots.Item1, roots.Item2);

            question:
            Console.WriteLine("Deseja rodar o programa novamente? 1-Sim 2-Não");
            string asw = Console.ReadLine();
            
            switch(asw){
                case "1":
                    goto start;
                case "2":
                    break;
                default:
                    Console.WriteLine("Resposta inválida!");
                    goto question;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Regressao.Tipos;

namespace Regressao
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<long> arrayX = new List<long> { 36, 43, 49, 55, 61, 63, 69, 72, 74, 77 };
            //List<long> arrayY = new List<long> { 350, 330, 296, 252, 230, 218, 203, 196, 188, 167 };
            List<long> arrayX = new List<long> {1,2,3,4};
            List<long> arrayY = new List<long> { 3,5,6,8};

            Console.WriteLine("0 Para Linear");
            Console.WriteLine("1 Para Exponencial");
            Console.WriteLine("2 Para Logaritimo");
            Console.WriteLine("3 Para Potencia");
            var parametro = Console.ReadLine();


            var correlacao = new Correlacao(arrayX, arrayY);
            Console.WriteLine($"A Correlação é: {correlacao.Confiabilidade} e sua classificação é {correlacao.Classificacao}");
            Console.WriteLine("---");


            for (int i = 0; i < 20; i++)
            {
            
                //Console.WriteLine($"Digite : ");
                //var proximoPonto = Convert.ToInt32(Console.ReadLine());
                IRegressao regressao = RefrecaoFactotry(parametro, arrayX, arrayY, i);
                Console.WriteLine($"{i}   {regressao.Previsao}");

            }

        }

        private static IRegressao RefrecaoFactotry(string parametro, List<long> eixoX, List<long> eixoY, int proximoPonto)
        {
            if (parametro.Equals("3")) return new Potencia(eixoX, eixoY, proximoPonto);
            if (parametro.Equals("2")) return new Logaritimica(eixoX, eixoY, proximoPonto);
            if (parametro.Equals("1")) return new Exponencial(eixoX, eixoY, proximoPonto);
            return new Linear(eixoX, eixoY, proximoPonto);


        }

    }
}


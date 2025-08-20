using System;
namespace RecursionDemo
{
    class Program
    {
        static int Fibonacci(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2); 
            
        }
        static void Main()
        {
            Console.WriteLine("Sequência de Fibonacci (10 primeiros termos): ");

            for (int i = 0; i < 10; i++)
            {
                Console.Write(Fibonacci(i) + " ");
            }

            Console.WriteLine();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multitrading__from_array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size;
            
            while (true)
            {
                Console.Write("Введите количество элементов массива: ");

                if (int.TryParse(Console.ReadLine(), out size)) break;
                else Console.WriteLine("Ошибка преобразования чтроки в число");
            }

            int[] arr = new int[size];
            var rand = new Random();

            for (int i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(0, 50);

            PrintArray(arr);

            IncrementArray(arr, 100);

            PrintArray(arr);

            Console.ReadKey();



            void IncrementArray(int[] _arr, int threadCount)
            {
                for (int i = 0; i < _arr.Length; i++)
                {
                    Thread thread = new Thread(Increment);
                    thread.Name = i.ToString();
                    thread.Start(i);                    
                }
            }

            void Increment(object index)
            {
                Thread.Sleep(1000);

                if(index is int)
                    arr[(int)index]++;

                Console.WriteLine($"Поток {Thread.CurrentThread.Name} выполнен");
            }

            void PrintArray(int[] array)
            {
                Console.WriteLine("\n\n");

                foreach (var item in array)
                    Console.Write($"{item}\t");

                Console.WriteLine("\n\n");
            }
        }
    }
}

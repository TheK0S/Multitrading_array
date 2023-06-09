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
        static Semaphore semaphore = new Semaphore(10, 10);
        static void Main(string[] args)
        {
            int size;
           
            while (true)
            {
                Console.Write("Введите количество элементов массива (введите более 10 чтобы заметить разницу): ");

                if (int.TryParse(Console.ReadLine(), out size)) break;
                else Console.WriteLine("Ошибка преобразования чтроки в число");
            }

            int[] arr = new int[size];
            var rand = new Random();

            for (int i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(0, 50);


            PrintArray(arr);

            IncrementArray(arr);

            //Ожидание завершения всех потоков
            Thread.Sleep(size * 1000 / 7);

            PrintArray(arr);

            Console.ReadKey();






            void IncrementArray(int[] _arr)
            {
                for (int i = 0; i < _arr.Length; i++)
                {
                    Thread thread = new Thread(Increment);
                    thread.Name = (i + 1).ToString();
                    thread.Start(i);
                }
            }

            void Increment(object index)
            {
                semaphore.WaitOne();

                Console.WriteLine($"Поток {Thread.CurrentThread.Name} запущен");

                Thread.Sleep(1000);

                arr[(int)index]++;

                Console.WriteLine($"Поток {Thread.CurrentThread.Name} выполнен!");

                semaphore.Release();
            }

            void PrintArray(int[] array)
            {
                Console.WriteLine("\n\n");

                for (int i = 0; i < array.Length; i++)
                {
                    if (i % 10 == 0) Console.WriteLine("\n");

                    Console.Write($"{array[i]}\t");
                }                    

                Console.WriteLine("\n\n");
            }
        }
    }
}

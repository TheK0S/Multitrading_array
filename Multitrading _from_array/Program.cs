using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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



            Console.ReadKey();
        }
    }
}

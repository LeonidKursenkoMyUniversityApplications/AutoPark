using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ввод выражения для записи в общую память
            int[] arrPoints = new int[]{1, 2, 3, 4, 5 };
            //Размер введенного сообщения
            int size = arrPoints.Length;
            MemoryMappedFile sharedMemory = MemoryMappedFile.CreateOrOpen("MemoryFile", size * 4 + 4);
            //Создаем объект для записи в разделяемый участок памяти
            using (MemoryMappedViewAccessor writer = sharedMemory.CreateViewAccessor(0, size * 4 + 4))
            {
                //запись в разделяемую память
                //запись размера с нулевого байта в разделяемой памяти
                writer.Write(0, size);
                //запись сообщения с четвертого байта в разделяемой памяти
                writer.WriteArray<int>(4, arrPoints, 0, arrPoints.Length);
            }

            Console.WriteLine("Сообщение записано в разделяемую память");
            Console.WriteLine("Для выхода из программы нажмите любую клавишу");
            Console.ReadLine();
        }
    }
}

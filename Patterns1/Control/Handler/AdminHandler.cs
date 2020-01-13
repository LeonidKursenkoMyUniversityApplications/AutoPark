using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParking.Control.Handler
{
    public class AdminHandler
    {
        public static void Send(string message)
        {
            string fileName = "SupportMessage.txt";
            using (TextWriter writer = File.CreateText(fileName))
            {
                writer.WriteLine(message);                
            }



            //int size = message.Length;
            //MemoryMappedFile sharedMemory = MemoryMappedFile.CreateOrOpen("Support", size * sizeof(char) + 4);
            //using (MemoryMappedViewAccessor writer = sharedMemory.CreateViewAccessor(0, size * sizeof(char) + 4))
            //{
            //    writer.Write(0, size);
            //    writer.WriteArray<char>(4, message.ToCharArray(), 0, message.Length);
            //}
        }
    }
}

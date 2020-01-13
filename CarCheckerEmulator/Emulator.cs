using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarCheckerEmulator
{
    public class Emulator
    {
        public void Check()
        {            
            int[] arrPoints = Result();
            int size = arrPoints.Length;
            MemoryMappedFile sharedMemory = MemoryMappedFile.CreateOrOpen("CheckCar", size * 4 + 4);
            using (MemoryMappedViewAccessor writer = sharedMemory.CreateViewAccessor(0, size * 4 + 4))
            {
                writer.Write(0, size);
                writer.WriteArray<int>(4, arrPoints, 0, arrPoints.Length);
            }

            Thread.Sleep(20000);
        }
        private int[] Result()
        {
            int[] arrPoints = new int[1000];
            //var random = new Random();
            for (int i = 0; i < arrPoints.Length; i++)
            {
                arrPoints[i] = i;//random.Next(400);
            }
            return arrPoints;
        }

    }
}

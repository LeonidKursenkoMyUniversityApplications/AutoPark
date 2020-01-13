using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LiftEmulator
{
    public class Emulator
    {
        public void Operation(bool isOk)
        {           
           
            MemoryMappedFile sharedMemory = MemoryMappedFile.CreateOrOpen("LiftFile", sizeof(bool));
            using (MemoryMappedViewAccessor writer = sharedMemory.CreateViewAccessor(0, sizeof(bool)))
            {
                writer.Write(0, isOk);
            }

            Thread.Sleep(20000);
        }
        
    }
}

using AutoParking.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoParking.Control.Handler
{
    public class LiftHandler
    {
        public static void Lift()
        {
            int attempts = 4;
            bool status = false;
            for(int i = 0; i < attempts; i++)
            {
                try
                {
                    status = TryUseLift();
                    break;
                }
                catch(LiftException)
                {
                    Thread.Sleep(1000);
                    continue;
                }
            }

            // Something is wrong
            if(status == false)
            {
                throw new LiftException("Operation with car wasn`t successful");
            }
        }

        private static bool TryUseLift()
        {
            bool status;
            MemoryMappedFile sharedMemory;
            try
            {
                sharedMemory = MemoryMappedFile.OpenExisting("LiftFile");
            }
            catch
            {
                throw new LiftException("Lift operation wasn`t successful");
            }
            using (MemoryMappedViewAccessor reader = sharedMemory.CreateViewAccessor(0, sizeof(bool), MemoryMappedFileAccess.Read))
            {
                status = reader.ReadBoolean(0);
            }
            
            return status;
        }
    }
}

using Patterns1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns1.Control.Handler
{
    public class FreeSpaceHandler
    {

        public static bool IsFree()
        {
            return AutoParkingDb.GetInstance().PlacesTable.IsFree();
        }

        public static Place FindFree()
        {
            return AutoParkingDb.GetInstance().PlacesTable.FindFreePlace();
        }

        public static string Result()
        {
            return (FreeSpaceHandler.IsFree() == true) ? "is available" : "is not available";
        }
    }
}

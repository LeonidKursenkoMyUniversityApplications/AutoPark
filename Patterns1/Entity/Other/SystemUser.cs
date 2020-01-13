using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns1.Entity.Other
{
    public class SystemUser
    {
        private static SystemUser instance;

        public Client Client { get; set; }

        private SystemUser()
        {

        }

        public static SystemUser GetInstance()
        {
            if(instance == null)
            {
                instance = new SystemUser();
            }
            return instance;
        }
    }
}

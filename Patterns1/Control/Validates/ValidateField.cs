using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Validates
{
    public class ValidateField
    {
        public static int ValidateKey(string ids, int oldId, List<int> idList)
        {
            int id = ValidateNumber(ids);
            
            if (id <= 0) throw new InputException("Invalid key value");

            if(id != oldId)
            {
                if(idList.Find(x => x == id) != 0) throw new InputException("Violation unique key");
            }
            return id;
        }
        public static int ValidateNumber(string nums)
        {
            int num = 0;
            try
            {
                num = Convert.ToInt32(nums);
            }
            catch 
            {
                throw new InputException("Incorrect symbols for integer field");
            }
            if (num < 0) throw new InputException("Value cannot be less then 0");
            return num;
        }

        public static string ValidateDate(string date)
        {

            DateTime d;
            try
            {
                d = DateTime.Parse(date);
            }
            catch
            {
                throw new InputException("Incorrect date format: " + date);
            }
            try
            {
                date = d.ToString("yyyy-MM-dd");
            }
            catch
            {
                throw new InputException("Incorrect date format");
            }

            return date;
        }

        public static string ValidateString(string str)
        {
            if(str == "") throw new InputException("Error, empty string");
            return str;
        }
        
    }
}

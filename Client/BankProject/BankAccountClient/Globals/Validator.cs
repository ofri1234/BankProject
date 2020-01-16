using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountClient.Globals
{
    class Validator
    {
        public static bool IsBetween(int length, int min, int max)
        {
            return length >= min && length <= max;
        }

        public static bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}

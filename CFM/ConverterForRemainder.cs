using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM
{
    public class ConverterForRemainder
    {
        public static string OnConvertingRemainder(double value, string fromUnit, string toUnit)
        {
            string messageRemainder = "";
            if (value < 64)
            {
                value = value % 64;
                messageRemainder = $"Стаков: {value}";
            }
            return messageRemainder;
        }
    }
}

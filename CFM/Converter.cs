using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM
{
    public class Converter
    {
        public static double ConvertValue(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == "Блок" && toUnit == "Стак")
            {
                return value / 64;
            }
            else if (fromUnit == "Блок" && toUnit == "Шалкер")
            {
                return value / 64 / 27;
            }
            else if (fromUnit == "Стак" && toUnit == "Шалкер")
            {
                return value / 27;
            }
            else if (fromUnit == "Шалкер" && toUnit == "Стак")
            {
                return value * 27;
            }
            else if (fromUnit == "Шалкер" && toUnit == "Блок")
            {
                return value * 64 * 27;
            }
            else if (fromUnit == "Стак" && toUnit == "Блок")
            {
                return value * 64;
            }
            else if (fromUnit == toUnit) // Добавлено для случая, если единицы измерения одинаковы
            {
                return value;
            }
            else
            {
                throw new ArgumentException("Неподдерживаемая комбинация единиц измерения.");
            }
        }
        public static string GetRemainder(double value, string fromUnit, string toUnit)
        {
            double convertedValue = ConvertValue(value, fromUnit, toUnit);
            long convertedValueLong = (long)convertedValue;

            if (fromUnit == "Блок" && toUnit == "Стак")
            {
                return (value % 64).ToString() + " единиц";
            }
            else if (fromUnit == "Блок" && toUnit == "Шалкер")
            {
                double remainderStacks = (value / 64) % 27;
                double remainderUnits = value % (64 * 27);
                return $"{remainderUnits} единиц, {remainderStacks} стаков";
            }
            else if (fromUnit == "Стак" && toUnit == "Шалкер")
            {
                double remainderUnits = (value % 27) * 64;
                return $"{remainderUnits} единиц, {value % 27} стаков";
            }
            else if (fromUnit == "Шалкер" && toUnit == "Стак")
            {
                return (convertedValueLong * 27 % 27).ToString() + " стаков";
            }
            else if (fromUnit == "Шалкер" && toUnit == "Блок")
            {
                return (value * 64 * 27 % 64).ToString() + " единиц";
            }
            else if (fromUnit == "Стак" && toUnit == "Блок")
            {
                return (value * 64 % 64).ToString() + " единиц";
            }
            else if (fromUnit == toUnit)
            {
                return "0 единиц";
            }
            else
            {
                throw new ArgumentException("Неподдерживаемая комбинация единиц измерения.");
            }
        }
    }
}

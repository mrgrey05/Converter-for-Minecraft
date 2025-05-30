using CFM.Properties;
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
            if (fromUnit == Resources.ConverterBlock && toUnit == Resources.ConverterStack)
            {
                return value / 64;
            }
            else if (fromUnit == Resources.ConverterBlock && toUnit == Resources.ConverterShulker)
            {
                return value / 64 / 27;
            }
            else if (fromUnit == Resources.ConverterStack && toUnit == Resources.ConverterShulker)
            {
                return value / 27;
            }
            else if (fromUnit == Resources.ConverterShulker && toUnit == Resources.ConverterStack)
            {
                return value * 27;
            }
            else if (fromUnit == Resources.ConverterShulker && toUnit == Resources.ConverterBlock)
            {
                return value * 64 * 27;
            }
            else if (fromUnit == Resources.ConverterStack && toUnit == Resources.ConverterBlock)
            {
                return value * 64;
            }
            else if (fromUnit == toUnit)
            {
                return value;
            }
            else
            {
                throw new ArgumentException(Resources.ConverterExceptionArg);
            }
        }
        public static string GetRemainder(double value, string fromUnit, string toUnit)
        {
            double convertedValue = ConvertValue(value, fromUnit, toUnit);
            long convertedValueLong = (long)convertedValue;

            if (fromUnit == Resources.ConverterBlock && toUnit == Resources.ConverterStack)
            {
                return (value % 64).ToString() + $" {Resources.ConverterUnits}";
            }
            else if (fromUnit == Resources.ConverterBlock && toUnit == Resources.ConverterShulker)
            {
                double remainderStacks = (value / 64) % 27;
                double remainderUnits = value % (64 * 27);
                return $"{remainderUnits} {Resources.ConverterUnits}, {remainderStacks} {Resources.ConverterStacks}";
            }
            else if (fromUnit == Resources.ConverterStack && toUnit == Resources.ConverterShulker)
            {
                double remainderUnits = (value % 27) * 64;
                return $"{remainderUnits} {Resources.ConverterUnits}, {value % 27} {Resources.ConverterStacks}";
            }
            else if (fromUnit == Resources.ConverterShulker && toUnit == Resources.ConverterStack)
            {
                return (convertedValueLong * 27 % 27).ToString() + $" {Resources.ConverterStacks}";
            }
            else if (fromUnit == Resources.ConverterShulker && toUnit == Resources.ConverterBlock)
            {
                return (value * 64 * 27 % 64).ToString() + $" {Resources.ConverterUnits}";
            }
            else if (fromUnit == Resources.ConverterStack && toUnit == Resources.ConverterBlock)
            {
                return (value * 64 % 64).ToString() + $" {Resources.ConverterUnits}";
            }
            else if (fromUnit == toUnit)
            {
                return $"0 {Resources.ConverterUnits}";
            }
            else
            {
                throw new ArgumentException("Неподдерживаемая комбинация единиц измерения.");
            }
        }
    }
}

using CFM.Properties;
using System;

namespace CFM
{
    public class Converter
    {
        /// <summary>
        /// Метод, отвечающий за конвертацию и вычисления с одной единицы в другую.
        /// </summary>
        /// <param name="value">Число</param>
        /// <param name="fromUnit">Первая вычисляемая единица</param>
        /// <param name="toUnit">Вторая вычисляемая единица</param>
        /// <returns>Число в другой единице.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static double ConvertValue(double value, string fromUnit, string toUnit, bool x16)
        {
            int stack = 64;
            if (x16 == true)
            {
                stack = 16;
            }
            else
            {
                stack = 64;
            }
            if (fromUnit == Resources.ConverterBlock && toUnit == Resources.ConverterStack)
            {
                return value / stack;
            }
            else if (fromUnit == Resources.ConverterBlock && toUnit == Resources.ConverterShulker)
            {
                return value / stack / 27;
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
                return value * stack * 27;
            }
            else if (fromUnit == Resources.ConverterStack && toUnit == Resources.ConverterBlock)
            {
                return value * stack;
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
        /// <summary>
        /// Метод, отвечающий за вычисление и вывод остатка.
        /// </summary>
        /// <param name="value">Число</param>
        /// <param name="fromUnit">Первая вычисляемая единица</param>
        /// <param name="toUnit">Вторая вычисляемая единица</param>
        /// <returns>Остаток числа</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GetRemainder(double value, string fromUnit, string toUnit, bool x16, bool IsOtherRemainder)
        {
            double convertedValue = ConvertValue(value, fromUnit, toUnit, x16);
            long convertedValueLong = (long)convertedValue;
            int stack = 64;
            if (x16 == true)
            {
                stack = 16;
            }
            else
            {
                stack = 64;
            }

            if (IsOtherRemainder)
            {
                if (fromUnit == Resources.ConverterBlock && toUnit == Resources.ConverterStack)
                {
                    return ((int)(value / stack)).ToString() + $" {Resources.ConverterStacks}, " + (value % stack).ToString() + $" {Resources.ConverterUnits}";
                }
                else if (fromUnit == Resources.ConverterBlock && toUnit == Resources.ConverterShulker)
                {
                    double remainderStacks = (value / stack) % 27;
                    double remainderUnits = value % (stack * 27);
                    return ((int)(value / stack / 27)).ToString() + $" {Resources.ConverterShulkers}," + $" {(int)remainderStacks} {Resources.ConverterStacks}, {remainderUnits - ((int)remainderStacks * stack)} {Resources.ConverterUnits}";
                }
                else if (fromUnit == Resources.ConverterStack && toUnit == Resources.ConverterShulker)
                {
                    double remainderUnits = (value % 27) * stack;
                    return ((int)(value / 27)).ToString() + $" {Resources.ConverterShulkers}," + $" {value % 27} {Resources.ConverterStacks}";
                }
                else if (fromUnit == Resources.ConverterShulker && toUnit == Resources.ConverterStack)
                {
                    return (convertedValueLong * 27 % 27).ToString() + $" {Resources.ConverterStacks}";
                }
                else if (fromUnit == Resources.ConverterShulker && toUnit == Resources.ConverterBlock)
                {
                    return (value * stack * 27 % stack).ToString() + $" {Resources.ConverterUnits}";
                }
                else if (fromUnit == Resources.ConverterStack && toUnit == Resources.ConverterBlock)
                {
                    return (value * stack % stack).ToString() + $" {Resources.ConverterUnits}";
                }
                else if (fromUnit == toUnit)
                {
                    return "нет";
                }
                else
                {
                    throw new ArgumentException(Resources.ConverterExceptionArg);
                }
            }
            else
            {
                if (fromUnit == Resources.ConverterBlock && toUnit == Resources.ConverterStack)
                {
                    return (value % stack).ToString() + $" {Resources.ConverterUnits}";
                }
                else if (fromUnit == Resources.ConverterBlock && toUnit == Resources.ConverterShulker)
                {
                    double remainderStacks = (value / stack) % 27;
                    double remainderUnits = value % (stack * 27);
                    return $"{remainderUnits} {Resources.ConverterUnits}, {remainderStacks} {Resources.ConverterStacks}";
                }
                else if (fromUnit == Resources.ConverterStack && toUnit == Resources.ConverterShulker)
                {
                    double remainderUnits = (value % 27) * stack;
                    return $"{remainderUnits} {Resources.ConverterUnits}, {value % 27} {Resources.ConverterStacks}";
                }
                else if (fromUnit == Resources.ConverterShulker && toUnit == Resources.ConverterStack)
                {
                    return (convertedValueLong * 27 % 27).ToString() + $" {Resources.ConverterStacks}";
                }
                else if (fromUnit == Resources.ConverterShulker && toUnit == Resources.ConverterBlock)
                {
                    return (value * stack * 27 % stack).ToString() + $" {Resources.ConverterUnits}";
                }
                else if (fromUnit == Resources.ConverterStack && toUnit == Resources.ConverterBlock)
                {
                    return (value * stack % stack).ToString() + $" {Resources.ConverterUnits}";
                }
                else if (fromUnit == toUnit)
                {
                    return $"0 {Resources.ConverterUnits}";
                }
                else
                {
                    throw new ArgumentException(Resources.ConverterExceptionArg);
                }
            }
        }
    }
}

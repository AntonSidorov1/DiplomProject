using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class ValueNumber
    {
        double valueReal = 0;

        public ValueNumber()
        {
        }

        public ValueNumber(double number) : this()
        {
            Value = number;
        }

        public ValueNumber(string number) : this()
        {
            ValueText = number;
        }

        public ValueNumber(double number, int decimalPlaces) : this(Math.Round(number, decimalPlaces))
        {
        }

        public ValueNumber(ValueNumber number, int decimalPlaces) : this(Math.Round(number.Value, decimalPlaces))
        {
        }

        public ValueNumber(ValueNumber number) : this(number.Value)
        {
        }



        public double ValueReal
        {
            get => valueReal;
            set => valueReal = value;
        }

        public double Value
        {
            get => ValueReal;
            set => ValueReal = value;
        }

        public string ValueText
        {
            get => Convert.ToString(Value);
            set
            {
                string number = value;
                number = number.Replace(',', ' ');
                number = number.Replace('.', ' ');
                number = number.Replace('_', ' ');
                number = number.Trim();

                number = number.Replace(' ', ',');
                try
                {
                    Value = Convert.ToDouble(number);
                }
                catch
                {
                    Value = 0;
                }
            }
        }

        public decimal ValueDecimal
        {
            get => Convert.ToDecimal(Value);
            set => Value = Convert.ToDouble(value);
        }

        public int ValueInt
        {
            get => (int)Value;
            set => Value = value;
        }

        public override string ToString()
        {
            return ValueText;
        }

        public static ValueNumber operator +(ValueNumber number1, int number2) => new ValueNumber(number1.Value + number2);

        public static ValueNumber operator +(ValueNumber number1, double number2) => new ValueNumber(number1.Value + number2);

        public static ValueNumber operator +(ValueNumber number1, ValueNumber number2)
        {
            return number1 + number2.Value;
        }

        public static ValueNumber operator -(ValueNumber number1, int number2) => new ValueNumber(number1.Value - number2);

        public static ValueNumber operator -(ValueNumber number1, double number2) => new ValueNumber(number1.Value - number2);

        public static ValueNumber operator *(ValueNumber number1, int number2) => new ValueNumber(number1.Value * number2);

        public static ValueNumber operator *(ValueNumber number1, double number2) => new ValueNumber(number1.Value * number2);

        public static ValueNumber operator *(ValueNumber number1, ValueNumber number2)
        {
            return (number1 * number2.Value);
        }

        public static ValueNumber operator -(ValueNumber number1, ValueNumber number2)
        {
            return number1 - number2.Value;
        }

        public static ValueNumber operator /(ValueNumber number1, int number2) => new ValueNumber(number1.Value / number2);

        public static ValueNumber operator /(ValueNumber number1, double number2) => new ValueNumber(number1.Value / number2);

        public static ValueNumber operator /(ValueNumber number1, ValueNumber number2)
        {
            return (number1 / number2.Value);
        }

        public static bool operator ==(ValueNumber number1, int number2) => number1.Value == number2;

        public static bool operator ==(ValueNumber number1, double number2) => number1.Value == number2;

        public static bool operator ==(ValueNumber number1, ValueNumber number2)
        {
            return number1 == number2.Value;
        }

        public static bool operator !=(ValueNumber number1, int number2) => number1.Value != number2;

        public static bool operator !=(ValueNumber number1, double number2) => number1.Value != number2;

        public static bool operator !=(ValueNumber number1, ValueNumber number2)
        {
            return number1 != number2.Value;
        }

    }
}

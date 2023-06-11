using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class ValuesInConrol
    {
        ValueNumber minValue = new ValueNumber(0);

        public ValueNumber MinValue
        {
            get => new ValueNumber(minValue, DecimalPlaces);
            set
            {
                minValue = new ValueNumber(value, DecimalPlaces);
                NormalizeValue();
            }
        }

        ValueNumber maxValue = new ValueNumber(100);

        public ValueNumber MaxValue
        {
            get
            {
                return new ValueNumber(maxValue, DecimalPlaces);
            }
            set
            {
                maxValue = new ValueNumber(value, DecimalPlaces);
                NormalizeValue();
            }
        }

        int decimalPlaces = 0;

        public int DecimalPlaces
        {
            get
            {
                return decimalPlaces;
            }
            set
            {
                decimalPlaces = value;
                NormalizeValue();
            }
        }

        ValueNumber valueNumber = new ValueNumber(0);


        public double NormalizeValue(double valueNumber)
        {
            valueNumber = Math.Round(valueNumber, 2);
            double min = Math.Min(MinValue.Value, MaxValue.Value);
            double max = Math.Max(MinValue.Value, MaxValue.Value);

            if (valueNumber > max)
                valueNumber = max;
            if (valueNumber < min)
                valueNumber = min;
            return valueNumber;
        }

        public void NormalizeValue() => SetNumber(valueNumber);

        public void SetNumber(ValueNumber valueNumber)
        {
            this.valueNumber = new ValueNumber(NormalizeValue(valueNumber.Value));
        }

        public ValueNumber GetNumber()
        {
            NormalizeValue();
            return valueNumber;
        }

        public ValueNumber Value
        {
            get => GetNumber();
            set => SetNumber(value);
        }

        ValueNumber increment = new ValueNumber(1);
        public ValueNumber Increment
        {
            get => increment;
            set => increment = value;
        }

        public void Plus()
        {
            Value += Increment;
        }

        public void Mines()
        {
            Value += Increment;
        }

        public void Clear()
        {
            Value *= 0;
        }
    }
}

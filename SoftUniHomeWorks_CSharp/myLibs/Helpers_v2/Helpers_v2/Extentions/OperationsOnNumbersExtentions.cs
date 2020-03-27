namespace Helpers_v2.Extentions
{
    using System;

    public static class OperationsOnNumbersExtentions
    {
        public static int Pow(this int number, int power)
        {
            int answer = 1;
            for (int i = 0; i < power; i++)
            {
                answer *= number;
            }

            return answer;
        }

        public static bool IsDevisibleByTwo(this int number) 
        {
            return ((number != 0) && ((number & (~number + 1)) == number));
        }

        public static int GetDigitAtPosition(this int number, int position) 
        {
            if (position < 0)
            {
                throw new ArgumentException("Position cant' be negative.");
            }

            int digit = (number / number.Pow(position)) % 10;
            return digit;
        }

        public static int PutZeroAt(this int number, int position)
        {
            int numberAtPosition = GetDigitAtPosition(number, position);
            number = number - (number.Pow(position) * numberAtPosition);
            return number;
        }

        public static int PutNumberAt(this int number, int numberToPut, int position)
        {
            number = number.PutZeroAt(position);
            number = number + ((10).Pow(position) * numberToPut);
            return number;
        }

        public static int DigitCount(this int number)
        {
            int digitCount = 1;
            while (number / 10 != 0)
            {
                digitCount++;
                number /= 10;
            }

            return digitCount;
        }

        public static bool IsPrime(this int number)
        {
            if (number <= 3)
            {
                if (number <= 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            if (number % 2 == 0 || number % 3 == 0)
            {
                return false;
            }

            for (int i = 5; i < Math.Sqrt(number) + 1; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static int Factorial(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Factorial of negative numbers is undefined.");
            }

            if (number == 0)
            {
                return 0;
            }

            if (number == 1)
            {
                return 1;
            }

            return Factorial(number - 1) * number;
        }
    }
}

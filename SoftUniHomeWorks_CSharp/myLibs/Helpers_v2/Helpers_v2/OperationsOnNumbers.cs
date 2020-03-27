namespace Helpers_v2
{
    public static class OperationsOnNumbers
    {
        public static int CalcGCD(int a, int b)
        {
            int remainder = a % b;
            int devidedValue = a / b;

            while (remainder > 0)
            {
                a = b;
                b = remainder;
                remainder = a % b;
                devidedValue = a / b;
            }

            return b;
        }

        public static long CalcGCD(long a, long b)
        {
            long remainder = a % b;
            long devidedValue = a / b;

            while (remainder > 0)
            {
                a = b;
                b = remainder;
                remainder = a % b;
                devidedValue = a / b;
            }

            return b;
        }

        public static int CalcLCM(int a, int b) 
        {
            return a / OperationsOnNumbers.CalcGCD(a, b) * b;
        }

        public static long CalcLCM(long a, long b)
        {
            return a / OperationsOnNumbers.CalcGCD(a, b) * b;
        }
    }
}

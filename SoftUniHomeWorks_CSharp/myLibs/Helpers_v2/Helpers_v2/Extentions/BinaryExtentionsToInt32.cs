namespace Helpers_v2.Extentions
{
    using System;

    public static class BinaryExtentionsToInt32
    {
        public static bool IsBitZeroAt(this int number, int position)
        {
            if (position < 0 || position > sizeof(Int32) * 8 - 1)
            {
                throw new ArgumentException("Position must be in [0..31]");
            }

            int mask = 1 << position;
            bool answer = (number & mask) == 0;
            return answer;
        }

        public static bool IsBitOneAt(this int number, int position)
        {
            if (position < 0 || position > sizeof(Int32) * 8 - 1)
            {
                throw new ArgumentException("Position must be in [0..31]");
            }

            int mask = 1 << position;
            bool answer = (number & mask) != 0;
            return answer;
        }

        public static bool GetBitAt(this int number, int position)
        {
            if (position < 0 || position > sizeof(Int32) * 8 - 1)
            {
                throw new ArgumentException("Position must be in [0..31]");
            }

            int mask = 1 << position;
            bool answer = (number & mask) != 0;
            return answer;
        }

        public static int ChangeBitAt(this int number, int position, bool newBit) 
        {
            if (position < 0 || position > sizeof(Int32) * 8 - 1)
            {
                throw new ArgumentException("Position must be in [0..31]");
            }

            int result = number;
            int mask = 1 << position;

            if (newBit)
            {
                // change the bit to one
                result = result | mask;
            }
            else
            {
                // change the bit to zero
                mask = ~ mask;
                result = result & mask;
            }

            return result;
        }

        public static int ExchangeBits(this int number, int firstPosition, int secondPosition)
        {
            if (firstPosition < 0 || firstPosition > sizeof(Int32) * 8 - 1)
            {
                throw new ArgumentException("Position must be in [0..31]");
            }

            if (firstPosition < 0 || secondPosition > sizeof(Int32) * 8 - 1)
            {
                throw new ArgumentException("Position must be in [0..31]");
            }

            bool bitAtFirstPosition = number.GetBitAt(firstPosition);
            bool bitAtSecondPosition = number.GetBitAt(secondPosition);
            int result = number;

            result = result.ChangeBitAt(secondPosition, bitAtFirstPosition);
            result = result.ChangeBitAt(firstPosition, bitAtSecondPosition);
            return result;
        }
    }
}

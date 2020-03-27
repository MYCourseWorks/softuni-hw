namespace Helpers_v2.Extentions
{
    using System;
    
    public static class ObjectExtensions
    {
        private const int seedPrimeNumber = 691;
        private const int fieldPrimeNumber = 397;

        public static int GetHashCodeFromFields(this object obj, params object[] fields)
        {
            unchecked
            {
                int hashCode = seedPrimeNumber;
                for (int i = 0; i < fields.Length; i++)
                {
                    if (fields[i] != null)
                        hashCode *= fieldPrimeNumber + fields[i].GetHashCode();
                }

                return hashCode;
            }
        }
    }
}

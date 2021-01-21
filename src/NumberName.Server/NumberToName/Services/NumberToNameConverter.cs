using System;
using System.Text;

namespace NumberName.Server.NumberToName.Services
{
    public static class NumberToNameConverter
    {
        static readonly string _zero = "zero";

        static readonly string[] _zeroToTeens = new string[]
        {
            String.Empty,
            "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
            "ten", "eleven", "twelve",
            "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        };

        static readonly string[] _tenMultiples = new string[]
        {
            String.Empty, String.Empty, "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
        };

        private enum Period
        {
            Hundred = 0,
            Thousand = 1,
            Million = 2,
            Billion = 3
        };

        static readonly string[] _periodText = new string[] { "hundred", "thousand", "million", "billion" };

        private const UInt32 BillionPeriodBegin = 1000000000;
        private const UInt32 MillionPeriodBegin = 1000000;
        private const UInt32 ThousandPeriodBegin = 1000;
        private const UInt32 HundredPeriodBegin = 100;
        private const UInt32 TenPeriodBegin = 10;
        private const UInt32 MagicTwenty = 20;

        // MaxValue
        // = 2^32
        // = 4,294,967,295 
        // = Four Billion Two Hundred Ninety Four Million Nine Hundred Sixty Seven Thousand Two Hundred Ninety Five
        public static string ConvertToWords(this UInt32 value)
        {
            var valueInWords = new StringBuilder();

            if (value == 0)
            {
                valueInWords.Append(_zero);
            }
            else
            {
                value
                    .ConvertForPeriod(valueInWords, Period.Billion, BillionPeriodBegin)
                    .ConvertForPeriod(valueInWords, Period.Million, MillionPeriodBegin)
                    .ConvertForPeriod(valueInWords, Period.Thousand, ThousandPeriodBegin)
                    .ConvertForPeriod(valueInWords, Period.Hundred, HundredPeriodBegin)
                    .ConvertSubHundred(valueInWords)
                    .ConvertSubTwenty(valueInWords);
            }

            return BuildNumberWord(valueInWords);
        }

        private static UInt32 ConvertForPeriod(this UInt32 value, StringBuilder valueInWords, Period period, UInt32 periodBegin)
        {
            if (value < periodBegin)
            {
                return value;
            }

            var periodValue = value / periodBegin;

            periodValue
                .ConvertForPeriod(valueInWords, Period.Hundred, HundredPeriodBegin)
                .ConvertSubHundred(valueInWords)
                .ConvertSubTwenty(valueInWords);

            valueInWords.Append($"{_periodText[(int)period]} ");

            return value % periodBegin;
        }

        private static UInt32 ConvertSubHundred(this UInt32 value, StringBuilder valueInWords)
        {
            if (value < MagicTwenty)
            {
                return value;
            }

            var periodValue = value / TenPeriodBegin;

            valueInWords.Append($"{_tenMultiples[periodValue]} ");

            return value % TenPeriodBegin;
        }

        private static UInt32 ConvertSubTwenty(this UInt32 value, StringBuilder valueInWords)
        {
            if (value >= MagicTwenty)
            {
                return value;
            }

            if (value != 0)
            {
                valueInWords.Append($"{_zeroToTeens[value]} ");
            }

            return 0;
        }

        private static string BuildNumberWord(StringBuilder valueInWords)
        {
            var startLetter = valueInWords[0].ToString().ToUpper();

            valueInWords.Remove(0, 1).Insert(0, startLetter);

            return valueInWords.ToString().TrimEnd();
        }
    }
}
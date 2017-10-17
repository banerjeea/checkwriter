using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeWriter.Services
{
    public interface INumberConverter
    {
        StringBuilder NumberToWords(int num, StringBuilder word);

    }

    /// <summary>
    /// Converts numericals to words.
    /// </summary>
    public class NumberConverter : INumberConverter
    {
        public StringBuilder NumberToWords(int num, StringBuilder word)
        {
            if (num == 0)
            {
                word.Append(" zero");
                return word;
            }

            if (num / 1000000000 > 0)
            {
                NumberToWords(num / 1000000000, word);
                word.Append(" billion");
                num %= 1000000000;
            }

            if (num / 1000000 > 0)
            {
                if (word.ToString().Contains("billion"))
                    word.Append(",");

                NumberToWords(num / 1000000, word);
                word.Append(" million");
                num %= 1000000;
            }

            if (num / 1000 > 0)
            {
                if (word.ToString().Contains("million"))
                    word.Append(",");

                NumberToWords(num / 1000, word);
                word.Append(" thousand");
                num %= 1000;
            }

            if (num / 100 > 0)
            {
                if (word.ToString().Contains("thousand"))
                    word.Append(",");

                word.Append(UniqueWords(num / 100) + " hundred");
                num %= 100;
            }

            if (num > 0 && num <= 20)
            {
                if (word.Length > 0)
                    word.Append(" and");
                word.Append(UniqueWords(num));
                return word;
            }

            if (num > 20 && num <= 99)
            {
                if (word.Length > 0)
                    word.Append(" and");
                word.Append(UniqueWords(num - num % 10));
                word.Append(UniqueWords(num % 10));
                return word;
            }

            return word;
        }

        private string UniqueWords(int num)
        {
            var dictOnes = new Dictionary<int, string> {{1, " one"}, {2, " two"},
                {3, " three"}, { 4, " four" }, { 5, " five" },
                {6, " six" }, {7, " seven"}, {8, " eight"},
                {9, " nine"},{10, " ten"},{11, " eleven"}, {12, " twelve"},{13, " thirteen"},
                {14, " fourteen"},{15, " fifteen"}, {16, " sixteen"}, {17, " seventeen"}, {18, " eighteen"},
                {19, " nineteen"}, {20, " twenty"},{30, " thirty"}, {40, " forty"}, {50, " fifty"},
                {60, " sixty"}, {70, " seventy"},{80, " eighty"}, {90, " ninety"} };

            string result;
            dictOnes.TryGetValue(num, out result);
            return result;
        }


    }
}

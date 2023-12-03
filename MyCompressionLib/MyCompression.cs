using System.Text;

namespace MyCompressionLib
{
    public class MyCompression
    {
        /// <summary>
        /// Алгоритм компрессии строки, замещающий группы последовательно идущих одинаковых букв формой "sc" (где "s" - символ, а "c" - количество букв в группе
        /// </summary>
        /// <param name="input">Входная строка с буквами латинского алфавита, в нижнем регистре</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">empty string</exception>
        public static string Compression(string input)
        {
            if(string.IsNullOrEmpty(input))
                throw new ArgumentNullException("empty string");

            var result = new StringBuilder();

            var previosElement = input.First();
            var countSameElements = 1;

            foreach(var element in input.Skip(1))
            {
                if (element == previosElement)
                    countSameElements++;
                else
                {
                    AppendElementsToResult();

                    countSameElements = 1;
                    previosElement = element;
                }
            }

            AppendElementsToResult();

            return result.ToString();

            void AppendElementsToResult()
            {
                result.Append(previosElement);

                if (countSameElements > 1)
                    result.Append(countSameElements);
            }
        }

        /// <summary>
        /// Алгоритм декомпрессии строки, в форме преобразованной в методе Compression()
        /// </summary>
        /// <param name="input">Входная строка с буквами латинского алфавита в нижнем регистре и цифрами</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">empty string</exception>
        public static string Decompression(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException("empty string");

            var result = new StringBuilder();

            var previosElement = input.First();
            var countElement = new StringBuilder();

            foreach(var item in input.Skip(1))
            {
                if(char.IsDigit(item))
                    countElement.Append(item);
                else
                {
                    AppendElementsToResult();

                    previosElement = item;
                }
            }

            AppendElementsToResult();

            return result.ToString();

            void AppendElementsToResult()
            {
                if (countElement.Length == 0)
                    result.Append(previosElement);
                else
                    for (var i = 1; i <= int.Parse(countElement.ToString()); i++)
                        result.Append(previosElement);

                countElement.Clear();
            }
        }
    }
}
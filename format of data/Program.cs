using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace format_of_data
{
    class Program
    {
        static string ToRussianData(string input)
        {
            return Regex.Replace(input, "\\b(?<month>\\d{1,2})-(?<day>\\d{1,2})-(?<year>\\d{2,4})\\b", "${day}-${month}-${year}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Американский формат: ММ-ДД-ГГГГ");
            Console.WriteLine("Европейский формат: ДД-ММ-ГГГГ\n");
            string[] values = { "01-05-2019", "10-23-3265", "01-12-2020", "01-12-2020-", 
                "-01-05-2019", "3216-32-02", "62-65-82", "0-0-0", "01-01-0000", "1-2-3" }; 
            foreach (var item in values)
            {
                string pattern = @"^(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])-(\d{4})$";
                if (Regex.IsMatch(item, pattern))
                {
                    Console.WriteLine($"{item} --> {ToRussianData(item)}");
                }
                else
                {
                    Console.WriteLine($"У вас неправильный формат: {item}");
                }
            }
            Console.ReadLine();
        }
    }
}

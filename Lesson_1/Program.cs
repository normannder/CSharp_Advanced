using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> characters = new List<string>();
            List<int> numbers = new List<int>();

            string pathtofile  = @"C:\Users\Asus PC\Desktop\1.txt";
            string pathtofile2 = @"C:\Users\Asus PC\Desktop\2.txt";
            string pathtofile3 = @"C:\Users\Asus PC\Desktop\3.txt";
            using (StreamReader stream = new StreamReader(pathtofile))
            {
                int number;
                bool result;
                string[] str = stream.ReadToEnd().Split(' ');
                foreach (var item in str)
                {
                    result = int.TryParse(item, out number);
                    if (result)
                        numbers.Add(number);
                    else
                        characters.Add(item.ToString());
                }
                using (StreamWriter stream2 = new StreamWriter(pathtofile2))
                {
                    foreach(string line in characters)
                    {
                        stream2.WriteLine(line);
                    }
                }
                using (StreamWriter stream3 = new StreamWriter(pathtofile3))
                {
                    foreach (int item in numbers)
                    {
                        stream3.WriteLine(item);
                    }
                }
            }
            

        }
    }
}
            
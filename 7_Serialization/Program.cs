using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Newtonsoft.Json;

using static ITEA_Collections.Common.Extensions;

namespace IteaSerialization
{
    [System.Runtime.InteropServices.Guid("01FDEB4A-7B33-45DD-B2A4-18B5F1DEA96E")]
    class Program
    {
        static void Main(string[] args)
        {
        //    ReadFromFile("example.txt");
        //    WriteToFile("example1.txt", "Some data");
        //    AppendToFile("example1.txt", "1");
        //    ToConsole(ReadFromFile("example.txt", ""));
            Person person = new Person("Alex", Gender.Man, 21, "alexs98@gmail.com");
            List<Person> workers = new List<Person>
            {
                new Person("Pol", Gender.Man, 37, "pol@gmail.com"),
                new Person("Ann", Gender.Woman, 25, "ann@yahoo.com"),
                new Person("Alex", Gender.Man, 21, "alex@gmail.com"),
                new Person("Harry", Gender.Man, 58, "harry@yahoo.com"),
                new Person("Hermione", Gender.Woman, 18, "hermione@gmail.com"),
                new Person("Richard", Gender.Man, 19, "richard@gmail.com"),
                new Person("Barry", Gender.Man, 20, "richard@gmail.com"),
                new Person("Ron", Gender.Man, 24, "ron@yahoo.com"),
                new Person("Etc1", Gender.etc, 42, "etc1@yahoo.com"),
                new Person("Etc2", Gender.etc, 49, "etc2@gmail.com"),
                new Person("Harald", Gender.etc, 34, "harald@yahoo.com"),
                new Person("Bjorn", Gender.Man, 28, "bjorn@gmail.com"),
            };

            Company RellbaumCorp = new Company("RellbaumCorp");
            Department securityDept = new Department("SecurityDepartment");
            Department marketingDept = new Department("MarketingDepartment");
            Department developmentDept = new Department("DevelopmentDepartment");
            RellbaumCorp.AddDepartment(securityDept);
            RellbaumCorp.AddDepartment(marketingDept);
            RellbaumCorp.AddDepartment(developmentDept);

            Company apple = new Company("Apple");

            workers.ForEach(worker => 
            {
                if (worker.Age <= 20)
                    worker.SetToDepartment(marketingDept);
                else if (worker.Age > 20 && worker.Age <= 30)
                    worker.SetToDepartment(securityDept);
                else
                    worker.SetToDepartment(developmentDept);
            }) ;


            JsonSerialize("RellbaumCorpJson", RellbaumCorp);
            Company checkСorrectness = CompJsonDeserialize("RellbaumCorpJson");

            if (RellbaumCorp.Equals(checkСorrectness))
            {
                Console.WriteLine("correct");
            }
            else Console.WriteLine("incorrect");
        }
        
        #region Serialization
        public static void XmlSerialize<T>(string path, T obj) where T : class
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (var fs = new FileStream($"{path}.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }

            using (var stringwriter = new StringWriter())
            {
                formatter.Serialize(stringwriter, obj);
                ToConsole(stringwriter.ToString());
            }
        }

        public static void JsonSerialize<T>(string path, T obj) where T : class
        {
            using (var fs = new FileStream($"{path}.json", FileMode.OpenOrCreate))
            {
                string strObj = JsonConvert.SerializeObject(obj);
                byte[] data = strObj
                    .Select(x => (byte)x)
                    .ToArray();
                fs.Write(data, 0, data.Length);
                strObj
                    .Split(",")
                    .ToList()
                    .ForEach(x => ToConsole($"{x},", ConsoleColor.Green));
            }
        }

        public static Company CompJsonDeserialize(string path)
        {
            using (var streamReader = new StreamReader($"{path}.json"))
            {
                string dataStr = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Company>(dataStr);
            }
        }
        public static Department DeptJsonDeserialize(string path)
        {
            using (var streamReader = new StreamReader($"{path}.json"))
            {
                string dataStr = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Department>(dataStr);
            }
        }
        #endregion
        #region System.IO
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Path to file</param>
        public static void ReadFromFile(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                var startMemory = GC.GetTotalMemory(true);
                streamReader
                    .ReadToEnd()
                    .Split(';')
                    .ShowAll(separator: ";")
                    .Select(x => long.TryParse(x, out long l) ? l : (long?)null)
                    .Where(x => x != null)
                    .ShowAll(separator: ";");
                var endMemory = GC.GetTotalMemory(true);
                Console.WriteLine($"Total memory: {endMemory - startMemory}");
            }
        }

        public static void WriteToFile(string path, string data)
        {
            using (var fileWriter = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] array = data.Select(x => (byte)x).ToArray();
                fileWriter.Write(array, 0, array.Length);
            }

            //{
            //    FileStream fileWriter = new FileStream(path, FileMode.OpenOrCreate);
            //    try
            //    {
            //        byte[] array = data.Select(x => (byte)x).ToArray();
            //        fileWriter.Write(array, 0, array.Length);
            //    }
            //    finally
            //    {
            //        fileWriter?.Dispose();
            //    }
            //}

            using (var streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(data);
            }
        }

        public static void AppendToFile(string path, string data)
        {
            using (var fileWriter = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] array = data.Select(x => (byte)x).ToArray();
                long fileDataLength = fileWriter.Length;
                fileWriter.Seek(fileDataLength, SeekOrigin.Begin);
                //fileWriter.Seek(0, SeekOrigin.End);
                fileWriter.Write(array, 0, array.Length);
            }
            using (var fileWriter = new FileStream(path, FileMode.Append))
            {
                byte[] array = data.Select(x => (byte)x).ToArray();
                fileWriter.Write(array, 0, array.Length);
            }
        }

        public static string ReadFromFile(string path, string notExistingEx)
        {
            notExistingEx = string.IsNullOrEmpty(notExistingEx)
                ? "Create file!"
                : notExistingEx;
            try
            {
                using (var fileReader = new FileStream(path, FileMode.Open))
                {
                    byte[] data = new byte[fileReader.Length];
                    fileReader.Read(data, 0, (int)fileReader.Length);
                    //return string.Concat(data.Select(x => (char)x));
                    return Encoding.Default.GetString(data);
                }
            }
            catch (FileNotFoundException)
            {
                ToConsole(notExistingEx, ConsoleColor.Red);
                return "Error";
            }
        }
        #endregion
    }
}

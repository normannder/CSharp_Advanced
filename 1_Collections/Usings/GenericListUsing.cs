using System;
using System.Collections.Generic;

using ITEA_Collections.Common;

namespace ITEA_Collections.Usings
{
    internal class GenericListUsing : IBaseCollectionUsing
    {
        public List<string> List { get; set; }

        public GenericListUsing()
        {
            List = new List<string>();
        }

        public void Add(object ts)
        {
            List.Add(ts.ToString());
        }

        public void AddMany(object[] ts)
        {
            if (ts is null)
                Extensions.ToConsole($"Array is null!", ConsoleColor.Red);
            else
                foreach (var item in ts)
                    List.Add(item.ToString());
        }

        public void Clear()
        {
            List.Clear();
        }

        public object GetByID(int index)
        {
            try
            {
                return List[index];
            }
            catch (Exception ex)
            {
                Extensions.ToConsole(ex.GetType().Name + ex.Message);
                Extensions.ToConsole($"No element with index: {index}", ConsoleColor.Red);
                return null;
            }
        }

        public void RemoveByID(int index)
        {
            try
            {
                List.RemoveAt(index);
                Extensions.ToConsole($"Successfully removed #{index}", ConsoleColor.DarkYellow);
            }
            catch (ArgumentOutOfRangeException)
            {
                Extensions.ToConsole($"No element with index: {index}", ConsoleColor.Red);
            }
        }

        public object[] GetAll()
        {
            return List.GetRange(0, List.Count).ToArray();
        }

        public void ShowAll()
        {
            foreach (var item in GetAll())
                Extensions.ToConsole($"{List.IndexOf(item.ToString())}: {item}, type - {item.GetType().Name}", ConsoleColor.Cyan);
        }
    }
}

using System;
using System.Collections.Generic;

using ITEA_Collections.Common;

namespace ITEA_Collections.Usings
{
    public class DictionaryUsing : IBaseCollectionUsing
    {
        public Dictionary<int, string> Dictionary { get; set; }

        public DictionaryUsing()
        {
            Dictionary = new Dictionary<int, string>();
        }

        public void Add(object ts)
        {
            int key = 0;
            Dictionary.Add(key++, ts.ToString());
        }

        public void AddMany(object[] ts)
        {
            int key = 0;
            foreach (var item in ts)
            {
                Dictionary.Add(key++, item.ToString());
            }
        }

        public void Clear()
        {
            Dictionary.Clear();
        }

        public object[] GetAll()
        {
            object[] arrayToReturn = new object[Dictionary.Count];
            foreach (var item in Dictionary)
            {
                for (int i = 0; i < Dictionary.Count; i++)
                {
                    arrayToReturn[i] = item;
                }
            }
            return arrayToReturn;
        }

        public object GetByID(int index)
        {
            try
            {
                return Dictionary[index];
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
                Dictionary.Remove(index);
                Extensions.ToConsole($"Successfully removed #{index}", ConsoleColor.DarkYellow);
            }
            catch (ArgumentOutOfRangeException)
            {
                Extensions.ToConsole($"No element with index: {index}", ConsoleColor.Red);
            }
        }

        public void ShowAll()
        {
            int key = 0;
            foreach (var item in GetAll())
                Extensions.ToConsole($"{Dictionary[key++]}: {item}, type - {item.GetType().Name}", ConsoleColor.Cyan);
        }
    }
}

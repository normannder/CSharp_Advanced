namespace ITEA_Collections.Base
{
    public class Person : IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int Q { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Age}";
        }
    }
}

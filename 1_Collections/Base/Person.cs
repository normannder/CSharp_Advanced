namespace ITEA_Collections.Base
{
    public class Person : object
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Age}";
        }
    }
}

using Newtonsoft.Json;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace IteaSerialization
{
    [Serializable]
    public class Department : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Person> PeopleInDepartment { get; set; } = new List<Person>();

        
        protected Department() { }

        public Department(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}

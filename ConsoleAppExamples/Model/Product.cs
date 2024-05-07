using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppExamples.Model
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; } = string.Empty;

        public Product(Guid id,string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}

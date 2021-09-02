using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMongoDBExample.Domains.Attributes
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DataBaseAttribute : Attribute
    {
        public DataBaseAttribute(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; init; }

    }
}

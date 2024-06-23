using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module24.ConsApp1
{
    public class Table
    {
        public Table()
        {
            Fields = new List<string>();
        }

        public string Name { get; set; }

        public List<string> Fields { get; set; }

        public string ImportantField { get; set; }

    }
}

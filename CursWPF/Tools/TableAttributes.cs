using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursWPF.Tools
{
    internal class TableAttributes : Attribute
    {
        public string Table { get; }
        public TableAttributes(string table)
        {
            Table = table;
        }
    }
}

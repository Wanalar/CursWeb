using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursWPF.Tools
{
    internal class ColumnAttributes : Attribute
    {
        public string Column { get; }
        public ColumnAttributes(string column)
        {
            Column = column;
        }
    }
}

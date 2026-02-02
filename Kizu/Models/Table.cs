using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kizu.Models
{
    public class Table : IComparable<Table>
    {
        public int Id { get; set; }
        public string Item { get; set; } = string.Empty;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int Cash { get; set; } = 0;
        public int Icoca { get; set; } = 0;
        public int Nanaco { get; set; } = 0;
        public int Coop { get; set; } = 0;

        public int CompareTo(Table other)
        {
            if (this == other) return 0;
            else if (DateTime.CompareTo(other.DateTime) is int value)
            {
                if (value == 0) return Id.CompareTo(other.Id);
                return value;
            }
            return 1;
        }
    }
}

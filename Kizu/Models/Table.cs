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
        public long Cash { get; set; } = 0;
        public long Icoca { get; set; } = 0;
        public long Nanaco { get; set; } = 0;
        public long Coop { get; set; } = 0;

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

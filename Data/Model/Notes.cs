using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Notes
    {
        public int Id { get; set; }

        public string Note { get; set; }

        public bool IsChecked { get; set; }

        public int UserId { get; set; }
    }
}

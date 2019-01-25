using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class Email
    {
        public int Id { get; set; }
        public string EndEmail { get; set; }

        override
        public string ToString()
        {
            return EndEmail;
        }
    }
}

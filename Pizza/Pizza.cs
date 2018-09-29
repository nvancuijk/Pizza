using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    public class Pizza
    {
        public List<string> Toppings { get; set; }

        public Pizza(string[] toppings)
        {
            Toppings = new List<string>(toppings);
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    public class Program
    {
        private static List<Pizza> pizzas = new List<Pizza>();
        static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader("pizzas.json"))
            {
                string json = r.ReadToEnd();
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);
            }

            var orderedConfigs = pizzas.Select(x => string.Join(",", x.Toppings.OrderBy(y => y)));
            var grouped = orderedConfigs.GroupBy(x => x);
            Dictionary<string, int> dToppingCounts = new Dictionary<string, int>();

            foreach (var g in grouped)
            {
                dToppingCounts.Add(g.Key, g.Count());
            }

            var orderedToppingCounts = dToppingCounts.OrderByDescending(x => x.Value);
            var top20ToppingCounts = orderedToppingCounts.Take(20);

            foreach (var t in top20ToppingCounts)
            {
                var topping = t.Key;
                Console.WriteLine("Topping : " + string.Join(",", topping) + "\t\t Frequency : " + t.Value);
            }

            Console.ReadLine();
        }
    }
}

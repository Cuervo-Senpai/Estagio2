using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_Remasterd_do_Remake
{
    internal class Analise
    {
        public void FrequencyNumber()
        {
            Security validation = new Security();
            Console.WriteLine("Write a number to Analyze: ");
            int numberAlalyze = validation.ConverserStringtoInt();

            int frequencyNumber = Print.results.SelectMany(c => c.Numbers).Count(n => n == numberAlalyze);

            Console.WriteLine($"Nº {numberAlalyze} saiu {frequencyNumber} vezes em {Print.results.Count} extrações, ({(double)frequencyNumber / (Print.results.Count) * 100:F2}%)");
        }
        public void TopFiveNumbers()
        {
            var frequencias = Print.results.SelectMany(c => c.Numbers).GroupBy(n => n).Select(g => new { Numero = g.Key, Frequency = g.Count() }).OrderByDescending(x => x.Frequency).Take(5);

            Console.WriteLine("Top 5 numbers most spawns:");
            foreach (var freq in frequencias)
            {
                Console.WriteLine($"Nº {freq.Numero} came out {freq.Frequency} times in {Print.results.Count} extractions, ({(double)freq.Frequency / (Print.results.Count) * 100:F2}%)");
            }
        }
    }
}

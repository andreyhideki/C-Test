using ConsoleAppExamples.Model.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppExamples.Model.Comparativos
{
    public class EnumCompare
    {
        string EnumComToString()
        {
            return ETipoPagamento.Dinheiro.ToString();
        }

        string EnumComNameOf()
        {
            return nameof(ETipoPagamento.Dinheiro);
        }

        string EnumComDisplayName()
        {
            return EnumExtensions.GetDisplayName(ETipoPagamento.Dinheiro);
        }

        public void CompararTempos()
        {
            Stopwatch stopwatch1 = new Stopwatch();

            stopwatch1.Start();
            EnumComToString();
            stopwatch1.Stop();

            TimeSpan time1 = stopwatch1.Elapsed;

            Stopwatch stopwatch2 = new Stopwatch();

            stopwatch2.Start();
            EnumComNameOf();
            stopwatch2.Stop();

            TimeSpan time2 = stopwatch2.Elapsed;

            Stopwatch stopwatch3 = new Stopwatch();

            stopwatch3.Start();
            EnumComDisplayName();
            stopwatch3.Stop();

            TimeSpan time3 = stopwatch3.Elapsed;

            
            List<TimeSpanWithDescription> listTimes = new List<TimeSpanWithDescription>();
            listTimes.Add(new TimeSpanWithDescription(time1, "EnumToString"));
            listTimes.Add(new TimeSpanWithDescription(time2, "EnumNameOf"));
            listTimes.Add(new TimeSpanWithDescription(time3, "EnumComDisplayName"));
            //listTimes.Sort();

            listTimes.Sort((x, y) => x.Time.CompareTo(y.Time));

            foreach (var time in listTimes)
            {
                Console.WriteLine($"Tempo com {time.Description} de: {time.Time.TotalMilliseconds} ms");
            }

            
        }
    }
}

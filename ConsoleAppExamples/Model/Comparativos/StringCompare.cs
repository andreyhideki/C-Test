using System.Diagnostics;

namespace ConsoleAppExamples.Model.Comparativos
{
    public class StringCompare
    {
        //Comparativo entre duas strings utilizando o == e o string.equals 
        //Comparison between two strings using == and string.equals

        static string shortText = "Texto 12345678910";
        static string shortText2 = shortText;


        static string LongText = "Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 Texto 12345678910 ";
        static string LongText2 = LongText;

        public bool ComUpper(string str1, string str2)
        {
            return str1.ToUpper() == str2.ToUpper();
        }

        public bool ComEqual(string str1, string str2)
        {
            return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
        }

        public void CompararStrings()
        {
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            ComUpper(shortText, shortText2);
            stopwatch1.Stop();
            TimeSpan time1 = stopwatch1.Elapsed;

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            ComEqual(shortText, shortText2);
            stopwatch2.Stop();
            TimeSpan time2 = stopwatch2.Elapsed;

            Stopwatch stopwatch3 = new Stopwatch();
            stopwatch3.Start();
            ComUpper(LongText, LongText2);
            stopwatch3.Stop();
            TimeSpan time3 = stopwatch3.Elapsed;

            Stopwatch stopwatch4 = new Stopwatch();
            stopwatch4.Start();
            ComEqual(LongText, LongText2);
            stopwatch4.Stop();
            TimeSpan time4 = stopwatch4.Elapsed;

            List<TimeSpanWithDescription> listTimes = new List<TimeSpanWithDescription>();
            listTimes.Add(new TimeSpanWithDescription(time1, "Short Text Com =="));
            listTimes.Add(new TimeSpanWithDescription(time2, "Short Text Com Equal"));
            listTimes.Add(new TimeSpanWithDescription(time3, "Long Text Com =="));
            listTimes.Add(new TimeSpanWithDescription(time4, "Long Text Com Equal"));


            listTimes.Sort((x, y) => x.Time.CompareTo(y.Time));

            foreach (var time in listTimes)
            {
                Console.WriteLine($"Tempo com {time.Description} de: {time.Time.TotalMilliseconds} ms");
            }

        }
    }
}

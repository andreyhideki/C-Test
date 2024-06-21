namespace ConsoleAppExamples.Model.Comparativos
{
    public class TimeSpanWithDescription
    {
        public TimeSpan Time { get; set; }
        public string Description { get; set; }

        public TimeSpanWithDescription(TimeSpan time, string description)
        {
            Time = time;
            Description = description;
        }
    }
}

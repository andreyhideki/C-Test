namespace ConsoleAppExamples.Model.Override
{
    public class DogAbstract : AnimalAbstract
    {
        public override void Speak()
        {
            Console.WriteLine("AU AU AU");
        }
    }
}

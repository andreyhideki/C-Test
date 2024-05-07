namespace ConsoleAppExamples.Model.Override
{
    public class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("AU AU AU");
        }
    }
}

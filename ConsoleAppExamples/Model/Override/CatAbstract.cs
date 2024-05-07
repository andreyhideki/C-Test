namespace ConsoleAppExamples.Model.Override
{
    public class CatAbstract : AnimalAbstract
    {
        public override void Speak()
        {
            Console.WriteLine("MIAU MIAU MIAU");
        }
    }
}

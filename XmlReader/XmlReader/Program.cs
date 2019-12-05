namespace XmlReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        protected static void Run()
        {
            ConsolePrint.ConsoleHeader();
            ReadXmls.ReadDirectory(ConsolePrint.GetDirectory(0));
        }
    }
}

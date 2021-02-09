namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Frontend.Frontend frontend = new Frontend.Frontend();
            frontend.start();
            //Persistence.MySqlCalculator p = new Persistence.MySqlCalculator();
            //p.loadResult();
        }
    }
}

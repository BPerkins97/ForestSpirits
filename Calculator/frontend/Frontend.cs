using System;
using Calculator.Business;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Frontend
{
    class Frontend : CalculatorDisplay
    {

        public void start ()
        {
            Business.Calculator calculator = new Business.Calculator(this, new Persistence.MySqlCalculator());
            Console.WriteLine("Bitte tippe die 2 Zahlen ein, die du addieren möchtest");
            int num1 = Int32.Parse(Console.ReadLine());
            int num2 = Int32.Parse(Console.ReadLine());
            calculator.add(num1, num2);
        }
        public void displayResult(int result)
        {
            Console.WriteLine("Ergebnis ist: " + result);
        }
    }
}

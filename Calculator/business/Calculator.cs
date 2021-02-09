namespace Calculator.Business
{
    class Calculator {
        private CalculatorDisplay display;
        private CalculatorPersistence persistence;
        public Calculator(CalculatorDisplay display, CalculatorPersistence persistence)
        {
            this.display = display;
            this.persistence = persistence;
        }

        public void add (int num1, int num2)
        {
            persistence.saveResult(num1 + num2);
            int result = persistence.loadResult();
            display.displayResult(result);
        }
    }

    public interface CalculatorPersistence
    {
        void saveResult(int num);
        int loadResult();
    }

    public interface CalculatorDisplay
    {
        void displayResult(int result);
    }
}

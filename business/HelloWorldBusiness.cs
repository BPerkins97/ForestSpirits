using System;

namespace ForestSpirits
{
    public class HelloWorldBusiness
    {
        private HelloWorldPersistence persistence;

        public HelloWorldBusiness(HelloWorldPersistence persistence)
        {
            this.persistence = persistence;
        }

        public String getMessage ()
        {
            Console.WriteLine("Load Hello World");
            return persistence.loadHelloWorld();
        }
    }

    public interface HelloWorldPersistence
    {
        String loadHelloWorld();
    }
}

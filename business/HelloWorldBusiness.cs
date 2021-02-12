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
            return persistence.loadHelloWorld();
        }
    }

    public interface HelloWorldPersistence
    {
        String loadHelloWorld();
    }
}

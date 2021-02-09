
using MySql.Data.MySqlClient;
using System;

namespace Calculator.Persistence
{
    class InMemoryCalculator : Business.CalculatorPersistence
    {
        private int lastResult;

        public int loadResult()
        {
            return lastResult;
        }

        public void saveResult(int num)
        {
            lastResult = num;
        }
    }

    class MySqlCalculator : Business.CalculatorPersistence
    {
        private MySqlConnection connection;

        public MySqlCalculator()
        {
            string connectionString = "server=localhost;user id=testuser;password=Password1234;port=3306;database=test";
            connection = new MySqlConnection(connectionString);
        }

        public int loadResult()
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM addition_log where id = 1";

            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string id = reader[0].ToString();
                string result = reader[1].ToString();
                return Int32.Parse(result);
                            
            }

            reader.Close();
            command.Dispose();
            connection.Close();
            return 0;
        }

        public void saveResult(int num)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = String.Format("INSERT into addition_log VALUES (1,{0})", num);

            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
        }
    }
}

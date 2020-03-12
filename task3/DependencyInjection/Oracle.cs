using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    class Oracle : IDataBase
    {
        public bool createDataBase(string name)
        {
            Console.WriteLine("Oracle DB {0} created", name);
            return true;
        }

        public bool createTable(string name)
        {
            Console.WriteLine("Oracle table {0} created", name);
            return true;
        }

        public bool dropTable(string name)
        {
            Console.WriteLine("Oracle table {0} dropped", name);
            return true;
        }

        public bool dropDataBase(string name)
        {
            Console.WriteLine("Oracle DB {0} dropped", name);
            return true;
        }

        public bool unionTables(string firstName, string secondName)
        {
            Console.WriteLine("Oracle DB {0} union with MySql DB {1}", firstName, secondName);
            return true;
        }

        public bool joinTables(string firstName, string secondName)
        {
            Console.WriteLine("Oracle DB {0} join with MySql DB {1}", firstName, secondName);
            return true;
        }
    }
}

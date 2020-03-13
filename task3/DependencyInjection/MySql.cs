using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    /// <summary>
    /// Class MySql describes methods for Oracle DBs, implements an IDataBase interface
    /// </summary>
    class MySql : IDataBase
    {
        /// <summary>
        /// Gets the name of DB and writes that DB with this name was created
        /// </summary>
        /// <param name="name"> name of DB </param>
        /// <returns>true or false depend on was the method successful</returns>
        public bool createDataBase(string name)
        {
            Console.WriteLine("MySql DB {0} created", name);
            return true;
        }

        /// <summary>
        /// Gets the name of Table and writes that Table with this name was created
        /// </summary>
        /// <param name="name"> name of Table </param>
        /// <returns>true or false depend on was the method successful</returns>
        public bool createTable(string name)
        {
            Console.WriteLine("MySql table {0} created", name);
            return true;
        }

        /// <summary>
        /// Gets the name of Table and writes that Table with this name was dropped
        /// </summary>
        /// <param name="name"> name of Table </param>
        /// <returns>true or false depend on was the method successful</returns>
        public bool dropTable(string name)
        {
            Console.WriteLine("MySql table {0} dropped", name);
            return true;
        }

        /// <summary>
        /// Gets the name of DB and writes that DB with this name was dropped
        /// </summary>
        /// <param name="name"> name of DB </param>
        /// <returns>true or false depend on was the method successful</returns>
        public bool dropDataBase(string name)
        {
            Console.WriteLine("MySql DB {0} dropped", name);
            return true;
        }

        /// <summary>
        /// Gets the names of Tables and writes that Tables with this names were unioned
        /// </summary>
        /// <param name="firstName"> name of Table </param>
        /// <param name="secondName"></param>
        /// <returns>true or false depend on was the method successful</returns>
        public bool unionTables(string firstName, string secondName)
        {
            Console.WriteLine("MySql DB {0} union with MySql DB {1}", firstName, secondName);
            return true;
        }

        /// <summary>
        /// Gets the names of Tables and writes that Tables with this names were joined
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <returns>true or false depend on was the method successful</returns>
        public bool joinTables(string firstName, string secondName)
        {
            Console.WriteLine("MySql DB {0} join with MySql DB {1}", firstName, secondName);
            return true;
        }
    }
}

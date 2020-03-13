using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    /// <summary>
    /// Class that defines type of DB and call method from appropriate class
    /// </summary>
    class DBWorker
    {
        IDataBase DataBase;

        /// <summary>
        /// Defines the type of DB
        /// </summary>
        /// <param name="type"></param>
        public DBWorker(DBTypes.Types type)
        {
            switch (type)
            {
                case DBTypes.Types.MySql:
                    DataBase = new MySql();
                    break;
                case DBTypes.Types.Oracle:
                    DataBase = new Oracle();
                    break;
            }
        }

        /// <summary>
        /// Calls the same method from defined class
        /// </summary>
        /// <param name="name">name of DB</param>
        /// <returns>true or false depend on was the method successful</returns>
        public bool createDataBase(string name)
        {
            return DataBase.createDataBase(name);
        }

        /// <summary>
        /// Calls the same method from defined class
        /// </summary>
        /// <param name="name">name of Table</param>
        /// <returns>true or false depend on was the method successful</returns>
        public bool createTable(string name)
        {
            return DataBase.createTable(name);
        }

        /// <summary>
        /// Calls the same method from defined class
        /// </summary>
        /// <param name="name">name of Table</param>
        /// <returns>true or false depend on was the method successful</returns>
        public bool dropTable(string name)
        {
            return DataBase.dropTable(name);
        }

        /// <summary>
        /// Calls the same method from defined class
        /// </summary>
        /// <param name="name">name of DB</param>
        /// <returns>true or false depend on was the method successful</returns>
        public bool dropDataBase(string name)
        {
            return DataBase.dropDataBase(name);
        }

        /// <summary>
        /// Calls the same method from defined class
        /// </summary>
        /// <param name="firstName">name of Table</param>
        /// <param name="secondName">name of Table</param>
        /// <returns>true or false depend on was the method successful</returns>
        public bool unionTables(string firstName, string secondName)
        {
            return DataBase.unionTables(firstName, secondName);
        }

        /// <summary>
        /// Calls the same method from defined class
        /// </summary>
        /// <param name="firstName">name of Table</param>
        /// <param name="secondName">name of Table</param>
        /// <returns>true or false depend on was the method successful</returns>
        public bool joinTables(string firstName, string secondName)
        {
            return DataBase.joinTables(firstName, secondName);
        }
    }
}
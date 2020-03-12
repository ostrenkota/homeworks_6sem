using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    class DBWorker
    {
        IDataBase DataBase;
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

        public bool createDataBase(string name)
        {
            return DataBase.createDataBase(name);
        }

        public bool createTable(string name)
        {
            return DataBase.createTable(name);
        }

        public bool dropTable(string name)
        {
            return DataBase.dropTable(name);
        }

        public bool dropDataBase(string name)
        {
            return DataBase.dropDataBase(name);
        }

        public bool unionTables(string firstName, string secondName)
        {
            return DataBase.unionTables(firstName, secondName);
        }

        public bool joinTables(string firstName, string secondName)
        {
            return DataBase.joinTables(firstName, secondName);
        }
    }
}
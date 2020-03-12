using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    interface IDataBase
    {
        bool createDataBase(string name);
        bool createTable(string name);
        bool dropTable(string name);
        bool dropDataBase(string name);
        bool unionTables(string firstName, string secondName);
        bool joinTables(string firstName, string secondName);
    }
}
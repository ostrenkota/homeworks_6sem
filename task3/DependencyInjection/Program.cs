using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите название СУБД:");
            bool succes = Enum.TryParse(Console.ReadLine(), out DBTypes.Types dbType);

            if (!succes)
            {
                Console.WriteLine("Данная СУБД не поддерживается.");
            }
            else
            {
                DBWorker Worker = new DBWorker(dbType);
                Worker.createDataBase("My cool DB");

                Console.WriteLine("Введите список действий:");

                string[] actions = Regex.Split(Console.ReadLine(), " ");

                for (int i = 0; i < actions.Length; i++)
                {
                    switch (actions[i]) 
                    {
                        case "createDataBase":
                            Worker.createDataBase("My cool DB");
                            break;

                    }
                }
            }

            Console.ReadKey();

        }
    }
}

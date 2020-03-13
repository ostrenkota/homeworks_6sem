using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
                Console.WriteLine("Введите название нужного метода (без аргументов)");
                string methodName = Console.ReadLine();

                try
                {
                    Type workerType = typeof(DBWorker);
                    object workerInstance = Activator.CreateInstance(workerType, dbType);
                    MethodInfo toInvoke = workerType.GetMethod(methodName);

                    try
                    {
                        Console.WriteLine("Сколько будет аргументов?");
                        int count = Int32.Parse(Console.ReadLine());

                        object[] arguments = new string[count];
                        Console.WriteLine("Введите аргументы:");
                        for (int i = 0; i < count; i++)
                        {
                            arguments[i] = Console.ReadLine();
                        }
                        toInvoke.Invoke(workerInstance, arguments);
                    }
                    catch
                    {
                        Console.WriteLine("Неверно заданы параметры.");
                    }
                }
                catch
                {
                    Console.WriteLine("Данный метод не поддерживается.");
                }
            }
            Console.ReadKey();
        }
    }
}
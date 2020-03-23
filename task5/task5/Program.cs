using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            int x = 1;
            int y = 2;
            int z = 8;
            int n = 4;
            int m = 2;

            context.SetVariable("x", x);
            context.SetVariable("y", y);
            context.SetVariable("z", z);
            context.SetVariable("n", n);
            context.SetVariable("m", m);
    
            IExpression expression = new SubtractExpression(
                new AddExpression(
                    new MultiplyExpression(
                    new NumberExpression("x"), new NumberExpression("y")
                ),
                new DivideExpression(new NumberExpression("z"), new NumberExpression("n"))
            ), new NumberExpression("m"));
         
            int result = expression.Interpret(context);
            Console.WriteLine("результат: {0}", result);

            Console.Read();
        }
    }

    /// <summary>
    /// Сlass describing a dictionary containing variable values
    /// </summary>
    class Context
    {
        Dictionary<string, int> variables;
        public Context()
        {
            variables = new Dictionary<string, int>();
        }

        /// <summary>
        /// Returns value by key 
        /// </summary>
        /// <param name="name">variable name</param>
        /// <returns>variable value</returns>
        public int GetVariable(string name)
        {
            return variables[name];
        }

        /// <summary>
        /// Add key and value to dictionary
        /// </summary>
        /// <param name="name">variable name</param>
        /// <param name="value">variable value</param>
        public void SetVariable(string name, int value)
        {
            if (variables.ContainsKey(name))
                variables[name] = value;
            else
                variables.Add(name, value);
        }
    }

    /// <summary>
    /// interpreter interface
    /// </summary>
    interface IExpression
    {
        int Interpret(Context context);
    }

    /// <summary>
    /// interpreter interface
    /// </summary>
    interface ISimpleExpression : IExpression{}

    /// <summary>
    /// describes terminal expression
    /// </summary>
    class NumberExpression : ISimpleExpression
    {
        string name;
        public NumberExpression(string variableName)
        {
            name = variableName;
        }

        /// <summary>
        /// return values
        /// </summary>
        /// <param name="context">dictionary</param>
        /// <returns>variables values</returns>
        public int Interpret(Context context)
        {
            return context.GetVariable(name);
        }
    }

    /// <summary>
    /// describes nonterminal expression for addition
    /// </summary>
    class AddExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;

        /// <summary>
        /// define the left and right operands
        /// </summary>
        /// <param name="left">left operand</param>
        /// <param name="right">right operand</param>
        public AddExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns>addition result</returns>
        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) + rightExpression.Interpret(context);
        }
    }

    /// <summary>
    /// describes nonterminal expression for subtraction
    /// </summary>
    class SubtractExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;

        /// <summary>
        /// define the left and right operands
        /// </summary>
        /// <param name="left">left operand</param>
        /// <param name="right">right operand</param>
        public SubtractExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns>subtraction result</returns>
        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) - rightExpression.Interpret(context);
        }
    }

    /// <summary>
    /// describes nonterminal expression for multiplication
    /// </summary>
    class MultiplyExpression : ISimpleExpression
    {
        ISimpleExpression leftExpression;
        ISimpleExpression rightExpression;

        /// <summary>
        /// define the left and right operands
        /// </summary>
        /// <param name="left">left operand</param>
        /// <param name="right">right operand</param>
        public MultiplyExpression(ISimpleExpression left, ISimpleExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns>multiplication result</returns>
        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) * rightExpression.Interpret(context);
        }
    }

    /// <summary>
    /// describes nonterminal expression for division
    /// </summary>
    class DivideExpression : ISimpleExpression
    {
        ISimpleExpression leftExpression;
        ISimpleExpression rightExpression;

        /// <summary>
        /// define the left and right operands
        /// </summary>
        /// <param name="left">left operand</param>
        /// <param name="right">right operand</param>
        public DivideExpression(ISimpleExpression left, ISimpleExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns>division result</returns>
        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) / rightExpression.Interpret(context);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;


namespace Task2
{
    /// <summary>
    ///  abstract class to describe goods properties
    /// </summary>
    abstract class Goods
    {
        public Goods(string name, double costs)
        {
            this.Name = name;
            this.Costs = costs;
        }

        public string Name { get; set; }
        public double Costs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>values ​​of all fields of the class instance</returns>
        public virtual string getInfo()
        {
            Trace.WriteLine("Getting info about " + this.Name);
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>fresh goods or not</returns>
        public abstract bool isFresh();
    }

    /// <summary>
    /// class to describe products properties
    /// </summary>
    class Product : Goods
    {  
        public Product(string name, double costs, DateTime produceDate, DateTime freshUntill) :
            base(name, costs)
        {
            this.ProduceDate = produceDate;
            this.FreshUntill = freshUntill;
        }

        public DateTime ProduceDate { get; set; }
        public DateTime FreshUntill { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>fresh goods or not</returns>
        public override bool isFresh()
        {
            bool isFresh = DateTime.Compare(DateTime.Now, FreshUntill) <= 0;

            Trace.WriteLine("Getting fresh status of " + this.Name + " product");
            Trace.Indent();
            Trace.WriteLineIf(isFresh, "The product " + this.Name + " is fresh");
            Trace.WriteLineIf(!isFresh, "The product " + this.Name + " is NOT fresh");
            Trace.Unindent();

            return isFresh;
        }

    }

    /// <summary>
    /// class to describe consigment properties
    /// </summary>
    class Consigment : Goods
    {
        public Consigment(int batch, string name, double costs, DateTime produceDate, DateTime freshUntill) :
             base(name, costs)
        {
            this.Batch = batch;
            this.ProduceDate = produceDate;
            this.FreshUntill = freshUntill;
        }

        public int Batch;
        public DateTime ProduceDate { get; set; }
        public DateTime FreshUntill { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>fresh goods or not</returns>
        public override bool isFresh()
        {
            bool isFresh = DateTime.Compare(DateTime.Now, FreshUntill) <= 0;

            Trace.WriteLine("Getting fresh status of " + this.Name + " consigment");
            Trace.Indent();
            Trace.WriteLineIf(isFresh, "The consigment " + this.Name + " is fresh");
            Trace.WriteLineIf(!isFresh, "The consigment " + this.Name + " is NOT fresh");
            Trace.Unindent();

            return isFresh;
        }
    }
    /// <summary>
    /// class to describe set of goods properties
    /// </summary>
    class Set : Goods
    {
        public Set(string name, double costs, Product[] products) :
            base(name, costs)
        {
            this.Products = products;
        }

        public Product[] Products;

        /// <summary>
        /// 
        /// </summary>
        /// <returns>whether all items in the set are fresh or not </returns>
        public override bool isFresh()
        {
            bool isFresh = Array.TrueForAll(Products, x => DateTime.Compare(DateTime.Now, x.FreshUntill) <= 0);

            Trace.WriteLine("Getting fresh status of " + this.Name + " consigment");
            Trace.Indent();
            Trace.WriteLineIf(isFresh, "The set " + this.Name + " is fresh");
            Trace.WriteLineIf(!isFresh, "The set " + this.Name + " is NOT fresh");
            Trace.Unindent();

            return isFresh;
        }
    } 
}

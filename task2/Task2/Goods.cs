using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace Task2
{
    abstract class Goods
    {
        public Goods(string name, double costs)
        {
            this.Name = name;
            this.Costs = costs;
        }

        public string Name { get; set; }
        public double Costs { get; set; }
        

        public virtual string getInfo()
        {
           return JsonConvert.SerializeObject(this);
        }
        public abstract bool isFresh();
    }

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

        public override bool isFresh()
        {
            return DateTime.Compare(DateTime.Now, FreshUntill) <= 0;
        }

    }

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

        public override bool isFresh()
        {
            return DateTime.Compare(DateTime.Now, FreshUntill) <= 0;
        }
    }

    class Set : Goods
    {
        public Set(string name, double costs, Product[] products) :
            base(name, costs)
        {
            this.Products = products;
        }

        public Product[] Products;

        public override bool isFresh()
        {
            return Array.TrueForAll(Products, x => DateTime.Compare(DateTime.Now, x.FreshUntill) <= 0);
        }
    } 
}

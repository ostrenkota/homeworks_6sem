using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonInfo;
            using (StreamReader sr = new StreamReader("../../../input.json"))
            {
                 jsonInfo = sr.ReadToEnd();
            }

            InputData info = JsonConvert.DeserializeObject<InputData>(jsonInfo);
            List<Goods> goodsList = new List<Goods>();
            goodsList.AddRange(info.Products);
            goodsList.AddRange(info.Consigments);
            goodsList.AddRange(info.Sets);
            var goodsArray = goodsList.ToArray();

            foreach(var elem in goodsArray)
            {
                Console.WriteLine(elem.getInfo());
            }

            Console.WriteLine("\n\nNot fresh goods list:\n");

            foreach (var elem in findNotFreshGoods(goodsArray))
            {
                Console.WriteLine(elem.Name);
            }

            Console.ReadKey();
        }

        public static Goods[] findNotFreshGoods(Goods[] goods)
        {
            List<Goods> notFreshist = new List<Goods>();
            foreach (var elem in goods)
            {
                if (!elem.isFresh())
                {
                    notFreshist.Add(elem);
                }
            }

            return notFreshist.ToArray();
        }
    }

    class InputData
    {
        public int n;
        public Product[] Products;
        public Consigment[] Consigments;
        public Set[] Sets;    
    }
}

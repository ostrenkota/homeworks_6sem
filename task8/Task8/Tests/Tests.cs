using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task8;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        DataWorker dataWorker = new DataWorker("test.xml");
        DataWorker dataWorker1 = new DataWorker("addTest.xml");
        DataWorker dataWorker2 = new DataWorker("deleteTest.xml");
        DataWorker dataWorker3 = new DataWorker("selectTest.xml");
        DataWorker dataWorker4 = new DataWorker("deleteTest1.xml");
        DataWorker dataWorker5 = new DataWorker("selectAllTest.xml");
        DataWorker dataWorker6 = new DataWorker("selectAllTest1.xml");

        Payment first = new Payment
        {
            House = 32,
            Flat = 101,
            Name = "White",
            Type = "газ",
            Date = DateTime.Parse("01.01.2001").Date,
            Amount = 350,
            Penalty = 0,
            Delay = 0
        };
        Payment second = new Payment
        {
            House = 3,
            Flat = 96,
            Name = "Black",
            Type = "вода",
            Date = DateTime.Parse("01.01.2005").Date,
            Amount = 500,
            Penalty = 0.5,
            Delay = 3
        };

        private bool ListEqals(List<Payment> list1, List<Payment> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }

            Payment[] arry1 = list1.ToArray();
            Payment[] arry2 = list2.ToArray();

            for (int i = 0; i < arry1.Length; i++)
            {
                if (!arry1[i].equals(arry2[i]))
                {
                    return false;
                }
            }

            return true;
        }

        [TestMethod]
        public void selectAllDataTest()
        {
            List<Payment> payments = dataWorker.selectAllData();
            Assert.IsTrue(ListEqals(payments, new List<Payment>(new Payment[] { first, second })));
        }

        [TestMethod]
        public void addDataTest() 
        {
            Payment third = new Payment
            {
                House = 1,
                Flat = 7,
                Name = "Петорв",
                Type = "газ",
                Date = DateTime.Parse("01.01.2003").Date,
                Amount = 500,
                Penalty = 0,
                Delay = 0
            };
            List<Payment> expected = dataWorker.selectAllData();
            dataWorker.AddElement(third.House, third.Flat, third.Name, third.Type, third.Date, third.Amount, third.Penalty, third.Delay);
            List<Payment> received = dataWorker.selectAllData();

            expected.Add(third);
            Assert.IsTrue(ListEqals(expected, received));
        }

        [TestMethod]
        public void deleteDataTest()
        { 
            Payment third = new Payment
            {
                House = 1,
                Flat = 7,
                Name = "Петорв",
                Type = "газ",
                Date = DateTime.Parse("01.01.2003").Date,
                Amount = 500,
                Penalty = 0,
                Delay = 0
            };
           
            List<Payment> expected = dataWorker.selectAllData();
            dataWorker.deleteElement(third.House.ToString(), third.Flat.ToString(), third.Name, third.Type, third.Date.ToString(), third.Amount.ToString(), third.Penalty.ToString(), third.Delay.ToString());
            List<Payment> received = dataWorker.selectAllData();

            expected.RemoveAt(expected.Count - 1);
            Assert.IsTrue(ListEqals(expected, received));
        }

        [TestMethod]
        public void selectDataTest()
        {
            Payment third = new Payment
            {
                House = 32,
                Flat = 101,
                Name = "White",
                Type = "газ",
                Date = DateTime.Parse("01.01.2001").Date,
                Amount = 350,
                Penalty = 0,
                Delay = 0
            };
            List<Payment> received = dataWorker.selectData(32);
            List<Payment> expected = new List<Payment>();
            expected.Add(third);
            Assert.IsTrue(ListEqals(received, expected));
        }

        [TestMethod]
        public void addDataTest1()
        {
            Payment third = new Payment
            {
                House = 1,
                Flat = 7,
                Name = "Петорв",
                Type = "вода",
                Date = DateTime.Parse("01.01.2008").Date,
                Amount = 500,
                Penalty = 0,
                Delay = 2
            };
            List<Payment> expected = dataWorker1.selectAllData();
            dataWorker1.AddElement(third.House, third.Flat, third.Name, third.Type, third.Date, third.Amount, third.Penalty, third.Delay);
            List<Payment> received = dataWorker1.selectAllData();

            expected.Add(third);
            Assert.IsTrue(ListEqals(expected, received));
        }

        [TestMethod]
        public void deleteDataTest1()
        {
            Payment third = new Payment
            {
                House = 1,
                Flat = 7,
                Name = "Петорв",
                Type = "вода",
                Date = DateTime.Parse("01.01.2008").Date,
                Amount = 500,
                Penalty = 0,
                Delay = 2
            };

            List<Payment> expected = dataWorker2.selectAllData();
            dataWorker2.deleteElement(third.House.ToString(), third.Flat.ToString(), third.Name, third.Type, third.Date.ToString(), third.Amount.ToString(), third.Penalty.ToString(), third.Delay.ToString());
            List<Payment> received = dataWorker2.selectAllData();

            expected.RemoveAt(expected.Count - 1);
            Assert.IsTrue(ListEqals(expected, received));
        }

        [TestMethod]
        public void addDataTest2()
        {
            Payment third = new Payment
            {
                House = 1,
                Flat = 7,
                Name = "Петорв",
                Type = "вода",
                Date = DateTime.Parse("01.01.2008").Date,
                Amount = 500,
                Penalty = 0,
                Delay = 2
            };
            List<Payment> expected = dataWorker2.selectAllData();
            dataWorker2.AddElement(third.House, third.Flat, third.Name, third.Type, third.Date, third.Amount, third.Penalty, third.Delay);
            List<Payment> received = dataWorker2.selectAllData();

            expected.Add(third);
            Assert.IsTrue(ListEqals(expected, received));
        }

        [TestMethod]
        public void selectDataTest1()
        {
            List<Payment> received = dataWorker3.selectData(1,7,"Петорв");
            List<Payment> expected = dataWorker3.selectAllData();
            expected.RemoveAt(0);
            Assert.IsTrue(ListEqals(received, expected));
        }

        [TestMethod]
        public void deleteDataTest2()
        {
            Payment third = new Payment
            {
                House = 2,
                Flat = 227,
                Name = "Алексеев",
                Type = "вода",
                Date = DateTime.Parse("01.01.2008").Date,
                Amount = 900,
                Penalty = 0,
                Delay = 2
            };

            List<Payment> expected = dataWorker4.selectAllData();
            dataWorker4.deleteElement(third.House.ToString(), third.Flat.ToString(), third.Name, third.Type, third.Date.ToString(), third.Amount.ToString(), third.Penalty.ToString(), third.Delay.ToString());
            List<Payment> received = dataWorker4.selectAllData();

            expected.RemoveAt(expected.Count - 1);
            Assert.IsTrue(ListEqals(expected, received));
        }

        [TestMethod]
        public void addDataTest3()
        {
            Payment third = new Payment
            {
                House = 2,
                Flat = 227,
                Name = "Алексеев",
                Type = "вода",
                Date = DateTime.Parse("01.01.2008").Date,
                Amount = 900,
                Penalty = 0,
                Delay = 2
            };
            List<Payment> expected = dataWorker4.selectAllData();
            dataWorker4.AddElement(third.House, third.Flat, third.Name, third.Type, third.Date, third.Amount, third.Penalty, third.Delay);
            List<Payment> received = dataWorker4.selectAllData();

            expected.Add(third);
            Assert.IsTrue(ListEqals(expected, received));
        }

        [TestMethod]
        public void selectAllDataTest1()
        {
            Payment third = new Payment
            {
                House = 1,
                Flat = 1,
                Name = "Иванов",
                Type = "электричество",
                Date = DateTime.Parse("01.01.2001").Date,
                Amount = 100,
                Penalty = 1,
                Delay = 1
            };
            List<Payment> payments = dataWorker5.selectAllData();
            List<Payment> expected = new List<Payment>();
            expected.Add(third);
            Assert.IsTrue(ListEqals(payments, expected));
        }

        [TestMethod]
        public void selectAllDataTest2()
        {
            Payment third = new Payment
            {
                House = 89,
                Flat = 89,
                Name = "Андреев",
                Type = "вода",
                Date = DateTime.Parse("01.01.2009").Date,
                Amount = 20,
                Penalty = 1,
                Delay = 1
            };
            Payment fourth = new Payment
            {
                House = 8,
                Flat = 8,
                Name = "Андрианов",
                Type = "вода",
                Date = DateTime.Parse("01.01.2009").Date,
                Amount = 30,
                Penalty = 1,
                Delay = 1
            };
            List<Payment> payments = dataWorker6.selectAllData();
            Assert.IsTrue(ListEqals(payments, new List<Payment>(new Payment[] { third, fourth })));
        }

    }
}

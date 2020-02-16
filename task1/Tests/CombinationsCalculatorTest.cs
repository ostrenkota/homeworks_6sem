using NUnit.Framework;
using Logic;
using System.Collections.Generic;
using System.IO;
using System;

namespace Tests
{
    [TestFixture]
    public class CombinationsCalculatorTest
    {
        [Test]
        public void checkCorrectValues()
        {
            var values = new List<(int, int)>()
                { (0, 1), (1, 1), (13, 4), (43, 25), (78, 84), (79, 84), (106, 178), (119, 224), (120, 251) };
            values.ForEach(x =>
            {
                Assert.AreEqual(x.Item2, CombinationsCalculator.sum(x.Item1));
            });
        }

        [Test]
        public void checkIncorrectValues()
        {
            var values = new List<(int, int)>()
                { (27, 13), (57, 43), (75, 85) };
            values.ForEach(x =>
            {
                Assert.AreNotEqual(x.Item2, CombinationsCalculator.sum(x.Item1));
            });
        }

        [Test]
        public void checkIncorrectInput()
        {
            string inpPath = "../input.txt";
            using (StreamWriter sw = new StreamWriter(inpPath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine("incorrect text");
            }
            var ex = Assert.Throws<ArgumentException>(() => CombinationsCalculator.Main(new string[0]));
            Assert.That(ex.Message, Is.EqualTo("Incorrect input"));
        }
    }
}
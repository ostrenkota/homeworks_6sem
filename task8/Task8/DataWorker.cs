using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task8
{
    class DataWorker
    {
        private List<Payment> data;
        private XDocument xdoc;
        private string path; 

        public DataWorker(string pathToXml)
        {
            path = pathToXml;
            xdoc = XDocument.Load(pathToXml);
          
            try
            {
                data = (from xe in xdoc.Element("paymentInfo").Elements("payment")
                        select new Payment
                        {
                            House = Int32.Parse(xe.Element("house").Value),
                            Flat = Int32.Parse(xe.Element("flat").Value),
                            Name = xe.Element("name").Value,
                            Type = xe.Element("type").Value,
                            Date = DateTime.Parse(xe.Element("date").Value).Date,
                            Amount = Double.Parse(xe.Element("amount").Value, CultureInfo.InvariantCulture),
                            Penalty = Double.Parse(xe.Element("penalty").Value, CultureInfo.InvariantCulture),
                            Delay = Int32.Parse(xe.Element("delay").Value)
                        }
                ).ToList();
            }
            catch
            {
                throw new ArgumentException("Xml file data has incorrect syntax");
            }      
        }

        public List<Payment> selectData(int house = 0, int flat = 0, string name = "", string type ="",
            DateTime date = default(DateTime))
        {
            List<Payment> correctItems = new List<Payment>();
            correctItems = data;
            if (house != 0)
            {

                correctItems = (from i in correctItems
                                where i.House == house
                                select i).ToList();
            }

            if (flat != 0)
            {
                correctItems = (from i in correctItems
                                where i.Flat == flat
                                select i).ToList();
            }

            if (name != "")
            {
                correctItems = (from i in correctItems
                                where i.Name == name
                                select i).ToList();
            }

            if (type != "")
            {
                correctItems = (from i in correctItems
                                where i.Type == type
                                select i).ToList();
            }


            if (date != default(DateTime))
            {
                correctItems = (from i in correctItems
                                where i.Date == date.Date
                                select i).ToList();
            }

            return correctItems;
        }

        public List<Payment> selectAllData()
        {
            return data;
        }

        public void deleteElement(string house, string flat, string name, string type, string date,
            string amount, string penalty, string delay)
        {
            foreach (XElement xe in xdoc.Element("paymentInfo").Elements("payment").ToList())
            {
                if (xe.Element("house").Value == house &&
                   xe.Element("flat").Value == flat &&
                   xe.Element("name").Value == name &&
                   xe.Element("type").Value == type &&
                   DateTime.Parse(xe.Element("date").Value) == DateTime.Parse(date) &&
                   xe.Element("amount").Value == amount &&
                   xe.Element("penalty").Value == penalty &&
                   xe.Element("delay").Value == delay)
                {
                    xe.Remove();
                }
            }
            xdoc.Save(path);
        }

        public void AddElement(int house, int flat, string name, string type, DateTime date,
            double amount, double penalty, int delay)
        {
            xdoc.Element("paymentInfo").Add(new XElement("payment",
                        new XElement("house", house),
                        new XElement("flat", flat),
                        new XElement("name", name),
                        new XElement("type", type),
                        new XElement("date", date),
                        new XElement("amount", amount),
                        new XElement("penalty", penalty),
                        new XElement("delay", delay)));
            xdoc.Save(path);

            data.Add(new Payment
            {
                House = house,
                Flat = flat,
                Name = name,
                Type = type,
                Date = date,
                Amount = amount,
                Penalty = penalty,
                Delay = delay
            });
        }

    }
}

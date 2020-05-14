using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    public class Payment
    {
        public int House { get; set; }
        public int Flat { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double Penalty { get; set; }
        public int Delay { get; set; }

        public bool equals(Payment pay)
        {
            return this.House == pay.House
                && this.Flat == pay.Flat
                && this.Name == pay.Name
                && this.Type == pay.Type
                && this.Date == pay.Date
                && this.Amount == pay.Amount
                && this.Penalty == pay.Penalty
                && this.Delay == pay.Delay;
        }

    }
}

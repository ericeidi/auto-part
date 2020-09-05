using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enFinalExam
{
    public class Battery : Item
    {
        private int voltage;

        public Battery()
        {
            voltage = 0;

        }

        public Battery(string nameItem, int voltage, int numberItem, int costItem, int weightItem, int quantity) : base(nameItem, numberItem, costItem, weightItem, quantity)
        {
            this.voltage = voltage;

        }

        public int Voltage
        {
            get => voltage;
            set => voltage = value;
        }

    }
}

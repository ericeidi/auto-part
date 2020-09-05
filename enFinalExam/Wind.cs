using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enFinalExam
{
    public class Wind : Item
    {
        private int wiper;

        public Wind()
        {
            wiper = 0;

        }

        public Wind(string nameItem, int voltage, int numberItem, int costItem, int weightItem, int quantity) : base(nameItem, numberItem, costItem, weightItem, quantity)
        {
            this.wiper = voltage;

        }

        public int Wiper
        {
            get => wiper;
            set => wiper = value;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enFinalExam
{
    public class Tire : Item
    {
        private string tireName;
        private int diameterName;

        public Tire()
        {
            tireName = "";
            diameterName = 0;

        }

        public Tire(string nameItem, string tireName, int diameterName, int numberItem, int costItem, int weightItem, int quantity) : base(nameItem, numberItem, costItem, weightItem, quantity)
        {
            this.tireName = tireName;
            this.diameterName = diameterName;

        }

        public string TireName
        {
            get => tireName;
            set => tireName = value;
        }

        public int DiameterName
        {
            get => diameterName;
            set => diameterName = value;
        }
    }
    
    
}

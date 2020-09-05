using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enFinalExam
{
    public class Item
    {
        private string nameItem;
        private int numberItem;
        private int costItem;
        private int weightItem;
        private int quantity;

        public Item()
        {
            nameItem = "";
            numberItem = 0;
            costItem = 0;
            weightItem = 0;
            quantity = 0;

        }

        public Item(string nameItem, int numberItem, int costItem, int weightItem, int quantity)
        {
            this.nameItem = nameItem;
            this.numberItem = numberItem;
            this.costItem = costItem;
            this.weightItem = weightItem;
            this.quantity = quantity;
        }

        public string NameItem
        {
            get => nameItem;
            set => nameItem = value;
        }

        public int NumberItem
        {
            get => numberItem;
            set => numberItem = value;
        }

        public int CostItem
        {
            get => costItem;
            set => costItem = value;
        }
        public int WeightItem
        {
            get => weightItem;
            set => weightItem = value;
        }

        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

    }
}

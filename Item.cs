using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAmazon
{
    public class Item
    {
        private string title;
        private string price;
        private string link;

        public Item(string title, string price, string link)
        {
            this.title = title;
            this.price = price;
            this.link = link;
        }
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }
        public string Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }
        public string Link
        {
            get
            {
                return this.link;
            }
            set
            {
                this.link = value;
            }
        }

        public string tostring()
        {
            return "product: " + this.title + "\n" + "price: " + this.price + "\n" + "url: " + this.link;
        }
    }
}

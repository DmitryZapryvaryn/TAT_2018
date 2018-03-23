using System.Collections.Generic;
using System.Text;

namespace Task_06.Entity
{
    class Warehouse
    {
        public Warehouse()
        {
            Products = new List<Product>();
        }

        public List<Product> Products { get; set; }

        public void AddProduct(Product product)
        {
            if (product != null)
            {
                Products.Add(product);
            }
        }

        public int GetCountTypes()
        {
            HashSet<string> uniqueTypes = new HashSet<string>();
            foreach(Product p in Products)
            {
                if (!uniqueTypes.Contains(p.Type))
                {
                    uniqueTypes.Add(p.Type);
                }
            }

            return uniqueTypes.Count;
        }

        public int GetCount()
        {
            int sum = 0;
            foreach (Product p in Products)
            {
                sum += p.Quantity;
            }

            return sum;
        }

        public int GetCount(string type)
        {
            int sum = 0;
            foreach (Product p in Products)
            {
                if(p.Type == type)
                    sum += p.Quantity;
            }

            return sum;
        }

        public double GetAveragePrice()
        {
            double sumPrice = 0.0;
            int count = 0;
            foreach (Product p in Products)
            {
                sumPrice += p.GetPrice();
                count += p.Quantity;
            }
            return sumPrice / count;
        }

        public double GetAveragePrice(string type)
        {
            double sumPrice = 0.0;
            int count = 0;
            foreach (Product p in Products)
            {
                if (p.Type == type)
                {
                    sumPrice += p.GetPrice();
                    count += p.Quantity;
                }
            }
            return sumPrice / count;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach(Product p in Products)
            {
                result.Append(p.ToString());
            }
            return result.ToString();
        }
    }
}

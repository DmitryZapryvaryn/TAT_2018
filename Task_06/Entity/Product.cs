using System.Collections.Generic;

namespace Task_06.Entity
{
    public class Product
    {

        public string Type { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return product != null &&
                   Type == product.Type &&
                   Name == product.Name &&
                   Quantity == product.Quantity &&
                   Price == product.Price;
        }

        public override int GetHashCode()
        {
            var hashCode = -1214702547;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Product: \n" + 
                "\t type: " + Type + "\n" +
                "\t name: " + Name + "\n" +
                "\t quantity: " + Quantity.ToString() + "\n" + 
                "\t price: " + Price.ToString() + "\n";
        }

        public double GetPrice()
        {
            return Price * Quantity;
        }

        public static ProductBuilder CreateBuilder()
        {
            return new ProductBuilder();
        }
    }
}

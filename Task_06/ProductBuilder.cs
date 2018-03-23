using System;
using System.Linq;
using Task_06.Entity;

namespace Task_06
{
    /// <summary>
    /// Build product using fluent interface
    /// </summary>
    public class ProductBuilder
    {
        private Product product;

        public ProductBuilder()
        {
            product = new Product();
        }

        public ProductBuilder SetType(string type)
        {
            if(type == string.Empty || type.Any(char.IsDigit))
            {
                throw new ArgumentException("Product type name must be non-empty and contain only char.", "type");
            }
            product.Type = type;
            return this;
        }

        public ProductBuilder SetName(string name)
        {
            if(name == string.Empty)
            {
                throw new ArgumentException("Product name must be non-empty.", "name");
            }
            product.Name = name;
            return this;
        }

        public ProductBuilder SetQuantity(int quantity)
        {
            if(quantity <= 0)
            {
                throw new ArgumentException("Product quantity must be greater than 0.", "quantity");
            }
            product.Quantity = quantity;
            return this;
        }

        public ProductBuilder SetPrice(double price)
        {
            if(price <= 0)
            {
                throw new ArgumentException("Product price must be greater than 0.", "price");
            }
            product.Price = price;
            return this;
        }

        /// <summary>
        /// Build product with parameters which set
        /// </summary>
        /// <returns>Setted product</returns>
        public Product Build()
        {
            return product;
        }
    }
}

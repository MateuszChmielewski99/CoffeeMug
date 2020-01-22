using CoffeeMug.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMug.Core.Domain.Models
{
    public class Product
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }

        public Product(Guid id, string name, decimal price)
        {
            Id = id;
            SetName(name);
            SetPrice(price);
        }

        public void SetName(string name)
        {
            if(name == null || name.Equals("")) 
            {
                throw new ModelException("Product name cannot be empty");
            }
            else if (name.Length > 100)
            {
                throw new ModelException("Product name cannot be longer then 100 chars");
            }
            else
            {
                this.Name = name;
            }
        }

        public void SetPrice(decimal price) 
        {
            if (price.Equals(decimal.Zero))
            {
                throw new ModelException("Product price cannot be empty");
            }
            else if (price < decimal.Zero)
            {
                throw new ModelException("Product price cannot be a negative number");
            }
            else 
            {
                Price = price;
            }
        }

    }
}

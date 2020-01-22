using System;
using System.Collections.Generic;
using System.Text;

namespace CofeeMug.Infrastructure.Commands
{
    public class CreateProductCommand: ICommand
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public decimal Price { get;  set; }
    }
}

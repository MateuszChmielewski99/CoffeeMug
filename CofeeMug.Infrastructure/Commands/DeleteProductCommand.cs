using System;
using System.Collections.Generic;
using System.Text;

namespace CofeeMug.Infrastructure.Commands
{
    public class DeleteProductCommand : ICommand
    {
        public Guid Id { get; set;}
    }
}

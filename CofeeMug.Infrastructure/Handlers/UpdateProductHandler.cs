using CofeeMug.Infrastructure.Commands;
using CofeeMug.Infrastructure.Services;
using CoffeeMug.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CofeeMug.Infrastructure.Handlers
{
    public class UpdateProductHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly IProductService _productService;

        public UpdateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task HandleAsync(UpdateProductCommand command)
        {
            await _productService.UpdateAsync(command.Id, command.Name, command.Price);
        }
    }
}

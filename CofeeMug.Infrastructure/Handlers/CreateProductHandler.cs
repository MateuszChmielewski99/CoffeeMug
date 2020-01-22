using CofeeMug.Infrastructure.Commands;
using CofeeMug.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CofeeMug.Infrastructure.Handlers
{
    public class CreateProductHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductService _productService;

        public CreateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task HandleAsync(CreateProductCommand command)
        {
            await _productService.AddAsync(command.Id, command.Name, command.Price);
        }
    }
}

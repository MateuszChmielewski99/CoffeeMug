using CofeeMug.Infrastructure.Commands;
using CofeeMug.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CofeeMug.Infrastructure.Handlers
{
    public class DeleteProductHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly IProductService _productService;

        public DeleteProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task HandleAsync(DeleteProductCommand command)
        {
            await _productService.DeleteAsync(command.Id);
        }
    }
}

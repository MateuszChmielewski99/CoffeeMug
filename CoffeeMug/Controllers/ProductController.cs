using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CofeeMug.Infrastructure.Commands;
using CofeeMug.Infrastructure.Handlers;
using CofeeMug.Infrastructure.Services;
using CoffeeMug.Core.Domain.Exceptions;
using CoffeeMug.Core.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMug.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly ICommandHandler<CreateProductCommand> _createHandler;
        private readonly ICommandHandler<UpdateProductCommand> _updateHandler;
        private readonly ICommandHandler<DeleteProductCommand> _deleteHandler;

        public ProductController(IProductService productService, ICommandHandler<CreateProductCommand> handler,
            ICommandHandler<UpdateProductCommand> updateHandler, ICommandHandler<DeleteProductCommand> deleteHandler)
        {
            _productService = productService;
            _createHandler = handler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productService.GetAllAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
        {
            command.Id = Guid.NewGuid();
            try
            {
                await _createHandler.HandleAsync(command);
            }
            catch (ModelException) 
            {
                return BadRequest();
            }
            return Created( $"$api/product/{command.Id}",new {id = command.Id});
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]UpdateProductCommand command)
        {
            command.Id = id;
            try
            {
                await _updateHandler.HandleAsync(command);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ModelException ex) 
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _deleteHandler.HandleAsync(new DeleteProductCommand { Id=id});
            }
            catch (ArgumentException ex) 
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }
    }
}

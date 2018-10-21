using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Domain;
using CQRS.Domain.Aggregates;
using CQRS.Domain.Commands;
using CQRS.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using OpenCqrs;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IDispatcher _dispatcher;

        public ProductController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var productId = Guid.NewGuid();
            var userId = Guid.NewGuid().ToString();
            const string source = "0";

            var newProduct = new CreateProduct
            {
                AggregateRootId = productId,
                Title = "My brand new product",
                UserId = userId,
              //  Source = source
            };

            // Create a new product (first domain event created).
            // ProductCreatedHandlerAsync should created the view model.
            await _dispatcher.SendAndPublishAsync<CreateProduct, Product>(newProduct);

            // Update title (second domain event created).
            // ProductTitleUpdatedHandlerAsync should update the view model with the new title.
            await _dispatcher.SendAndPublishAsync<UpdateProductTitle, Product>(new UpdateProductTitle
            {
                AggregateRootId = productId,
                Title = "Updated product title",
                UserId = userId,
               // Source = source,
                //ExpectedVersion = 1
            });


            // Get the view model that should return the title used in the last update.
            var product = await _dispatcher.GetResultAsync<GetProduct, ProductViewModel>(new GetProduct
            {
                Id = productId
            });

            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            var productId = Guid.Parse("3e0990f2-3875-4b7d-9e10-eed9c43ad103");
            await _dispatcher.SendAndPublishAsync<UpdateProductTitle, Product>(new UpdateProductTitle
            {
                AggregateRootId = productId,
                Title = "Updated product title",
                UserId = Guid.NewGuid().ToString(),
                // Source = source,
                //ExpectedVersion = 1
            });

            var product = await _dispatcher.GetResultAsync<GetProduct, ProductViewModel>(new GetProduct
            {
                Id = productId
            });

            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

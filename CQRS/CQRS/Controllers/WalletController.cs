using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Domain.EventFlow;
using CQRS.Domain.EventFlow.CommandHandlers;
using CQRS.Domain.EventFlow.Commands;
using CQRS.Domain.EventFlow.Events;
using CQRS.Domain.EventFlow.ReadModels;
using EventFlow;
using EventFlow.Extensions;
using EventFlow.MongoDB.Extensions;
using EventFlow.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            using (var resolver = EventFlowOptions.New
                .AddEvents(typeof(ProductCreated))
                .AddCommands(typeof(CreateProduct))
                .AddCommandHandlers(typeof(CreateProductHandler))
                .ConfigureMongoDb("mongodb+srv://cqrs_user:cqrs@cqrscluster-cgwnw.mongodb.net/test?retryWrites=true", 
                    "event-flow-store")
                //.UseInMemoryReadStoreFor<ProductReadModel>()
                
                .UseMongoDbEventStore()
                .UseMongoDbReadModel<ProductReadModelMongo>()

                //.RegisterServices(sr =>
                //{
                //    sr.Register<IProductReadModelLocator, ProductReadModelLocator>();
                //})

                //.UseMongoDbReadModel<ProductReadModelMongo, IProductReadModelLocator>()
                .CreateResolver(true))
            {
                // Create a new identity for our aggregate root
                var exampleId = ProductId.New;

                // Resolve the command bus and use it to publish a command
                var commandBus = resolver.Resolve<ICommandBus>();
                await commandBus.PublishAsync(
                        new CreateProduct(exampleId, 42), CancellationToken.None)
                    .ConfigureAwait(false);

                // Resolve the query handler and use the built-in query for fetching
                // read models by identity to get our read model representing the
                // state of our aggregate root
                var queryProcessor = resolver.Resolve<IQueryProcessor>();
                var exampleReadModel = await queryProcessor.ProcessAsync(
                        new ReadModelByIdQuery<ProductReadModel>(exampleId), CancellationToken.None)
                    .ConfigureAwait(false);

                // Verify that the read model has the expected magic number
               // exampleReadModel.MagicNumber.Should().Be(42);
            }

            return Ok();
        }
    }
}
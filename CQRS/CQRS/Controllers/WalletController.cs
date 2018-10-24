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
            string result = string.Empty;
            using (var resolver = EventFlowOptions.New
                .AddEvents(typeof(ProductCreated))
                .AddEvents(typeof(MagicNumberIcremented))
                .AddCommands(typeof(CreateProduct))
                .AddCommands(typeof(IncMagicNumber))
                .AddCommandHandlers(typeof(CreateProductHandler))
                .AddCommandHandlers(typeof(IncMagicNumberHandler))
                .ConfigureMongoDb("mongodb+srv://cqrs_user:cqrs@cqrscluster-cgwnw.mongodb.net/test?retryWrites=true", 
                    "event-flow-store")
                //.UseInMemoryReadStoreFor<ProductReadModel>()
                
                .UseMongoDbEventStore()
                .UseMongoDbSnapshotStore()
                .UseMongoDbReadModel<ProductReadModelMongo>()

                //.RegisterServices(sr =>
                //{
                //    sr.Register<IProductReadModelLocator, ProductReadModelLocator>();
                //})

                //.UseMongoDbReadModel<ProductReadModelMongo, IProductReadModelLocator>()
                .CreateResolver(true))
            {
                // Create a new identity for our aggregate root
                //var exampleId = ProductId.New;
                var exampleId = new ProductId("product-9f1f4f71-a83f-445a-9764-b0c457fc61a5");

                // Resolve the command bus and use it to publish a command
                var commandBus = resolver.Resolve<ICommandBus>();
                //await commandBus.PublishAsync(
                //        new CreateProduct(exampleId, 1), CancellationToken.None)
                //    .ConfigureAwait(false);

                await commandBus.PublishAsync(
                        new IncMagicNumber(exampleId, 1), CancellationToken.None)
                    .ConfigureAwait(false);


                // Resolve the query handler and use the built-in query for fetching
                // read models by identity to get our read model representing the
                // state of our aggregate root
                var queryProcessor = resolver.Resolve<IQueryProcessor>();
                var exampleReadModel = await queryProcessor.ProcessAsync(
                        new ReadModelByIdQuery<ProductReadModelMongo>(exampleId), CancellationToken.None)
                    .ConfigureAwait(false);
                result = exampleReadModel.MagicNumber.ToString();
                // Verify that the read model has the expected magic number
                // exampleReadModel.MagicNumber.Should().Be(42);
            }

            return Ok(result);
        }
    }
}
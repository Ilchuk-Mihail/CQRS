using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQRS.Domain.Queries;
using OpenCqrs.Queries;

namespace CQRS.Domain.QueryHandlers
{
    public class GetProductHandlerAsync : IQueryHandlerAsync<GetProduct, ProductViewModel>
    {
        public async Task<ProductViewModel> RetrieveAsync(GetProduct query)
        {
            await Task.CompletedTask;

            var model = FakeReadDatabase.Products.Find(x => x.Id == query.Id);
            return model;
        }
    }
}

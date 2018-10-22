using System;
using System.Collections.Generic;
using System.Text;
using EventFlow.Aggregates;
using EventFlow.ReadStores;

namespace CQRS.Domain.EventFlow.ReadModels
{
    public interface IProductReadModelLocator : IReadModelLocator { }

    public class ProductReadModelLocator : IProductReadModelLocator
    {
        public IEnumerable<string> GetReadModelIds(IDomainEvent domainEvent)
        {
            //yield return "some id based on some event";
            yield return Guid.NewGuid().ToString();
        }
    }
}

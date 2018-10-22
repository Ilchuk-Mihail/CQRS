using System;
using System.Collections.Generic;
using System.Text;
using EventFlow.Core;

namespace CQRS.Domain.EventFlow
{
    public class ProductId : Identity<ProductId>
    {
        public ProductId(string value) : base(value)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using OpenCqrs.Queries;

namespace CQRS.Domain.Queries
{
    public class GetProduct : IQuery
    {
        public Guid Id { get; set; }
    }
}

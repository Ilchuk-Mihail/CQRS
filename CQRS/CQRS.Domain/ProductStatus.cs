using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Domain
{
    public enum ProductStatus
    {
        Draft = 0,
        Published = 1,
        Deleted = 2
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Domain
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}

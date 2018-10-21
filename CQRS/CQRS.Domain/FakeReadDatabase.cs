using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Domain
{
    public static class FakeReadDatabase
    {
        public static List<ProductViewModel> Products = new List<ProductViewModel>();
    }
}

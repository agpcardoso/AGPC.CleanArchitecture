using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.SPA.Models.Customers
{
    public class GetListResponse
    {
        public IEnumerable<Customer> Customers { get; set; }

        public class Customer
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}

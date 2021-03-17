using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.SPA.Models.Customers
{
    public class PutRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}

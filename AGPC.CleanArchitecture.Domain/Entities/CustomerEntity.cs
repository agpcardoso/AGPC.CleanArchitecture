using System;

namespace AGPC.CleanArchitecture.Domain.Entities
{
    public class CustomerEntity : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public bool Underage()
           => (this.Age < 18);
        
    }
}

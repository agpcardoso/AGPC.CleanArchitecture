using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.Application.UseCases
{
    
    public class UseCaseException : Exception
    {
        public UseCaseException(string message) : base(message)   { }
    }


}

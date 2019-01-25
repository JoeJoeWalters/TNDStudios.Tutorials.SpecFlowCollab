using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNDStudios.Tutorials.SpecFlowCollab
{
    /// <summary>
    /// Incoming API Request Pattern
    /// </summary>
    public interface IAPIRequest<T> where T : IDomainObject
    { 
        /// <summary>
        /// The data in the request
        /// </summary>
        T Data { get; set; }
    }
}

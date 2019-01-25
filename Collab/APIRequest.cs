using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNDStudios.Tutorials.SpecFlowCollab
{
    /// <summary>
    /// Implementation of the API Request
    /// </summary>
    /// <typeparam name="T">The type of data in the incoming request</typeparam>
    public class APIRequest<T> : IAPIRequest<T> where T: IDomainObject
    {
        /// <summary>
        /// The data mapped to the correct object type
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public APIRequest()
        {
            Data = default(T);
        }
    }
}

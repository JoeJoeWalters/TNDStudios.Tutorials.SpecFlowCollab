using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNDStudios.Tutorials.SpecFlowCollab
{
    /// <summary>
    /// Implementation of the service bus handler
    /// </summary>
    public class ServiceBusHandler<T> : IServiceBusHandler<T> where T : IDomainObject
    {
        /// <summary>
        /// Save a set of objects to the service bus
        /// </summary>
        /// <param name="objectsToSave">The objects to save to the service bus</param>
        /// <returns>The amount of objects saved to the service bus</returns>
        public Int32 SaveObjects(List<T> objectsToSave)
            => objectsToSave.Count; // Fake until we write the actual code
    }
}

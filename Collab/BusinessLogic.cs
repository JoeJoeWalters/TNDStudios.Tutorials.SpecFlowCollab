using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNDStudios.Tutorials.SpecFlowCollab
{
    public class BusinessLogic
    {
        /// <summary>
        /// The injected service bus handler
        /// </summary>
        private IServiceBusHandler<IDomainObject> serviceBusHandler;
        
        /// <summary>
        /// Default Constructor to set up the business logic
        /// </summary>
        /// <param name="serviceBusHandler">The service bus handler to work with</param>
        public BusinessLogic(IServiceBusHandler<IDomainObject> serviceBusHandler)
            => this.serviceBusHandler = serviceBusHandler;

        /// <summary>
        /// Process a set of requests
        /// </summary>
        /// <returns>The amount of records successfully processed</returns>
        public Int32 ProcessRequest(IAPIRequest<IDomainObject> request)
            => this.serviceBusHandler.SaveObjects(
                new List<IDomainObject>()
                {
                    request.Data
                });
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNDStudios.Tutorials.SpecFlowCollab
{
    /// <summary>
    /// The service bus topic to send things to
    /// </summary>
    public enum ServiceBusTopic
    {
        Unknown = 0,
        PersonTopic = 1,
        AssetTopic = 2
    }

    /// <summary>
    /// Interface to handle saving the domain object to the correct service bus
    /// topic etc.
    /// </summary>
    /// <typeparam name="T">The type of data</typeparam>
    public class IServiceBusHandler<T> where T : IDomainObject
    {
        
    }
}

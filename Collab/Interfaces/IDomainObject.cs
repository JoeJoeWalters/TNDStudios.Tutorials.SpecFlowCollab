using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNDStudios.Tutorials.SpecFlowCollab
{
    /// <summary>
    /// Interface for all domain object items
    /// </summary>
    public interface IDomainObject
    {
        /// <summary>
        /// The record identifier
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Name of the object
        /// </summary>
        String Name { get; set; }

        /// <summary>
        /// Description of the object
        /// </summary>
        String Description { get; set; }

        /// <summary>
        /// Basic validation of the object
        /// </summary>
        /// <returns>If the object is valid</returns>
        Boolean IsValid { get; }
    }
}

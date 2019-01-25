using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNDStudios.Tutorials.SpecFlowCollab
{
    public class DomainObjectBase : IDomainObject
    {
        /// <summary>
        /// The record identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the object
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Description of the object
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Basic validation of the object
        /// </summary>
        /// <returns>If the object is valid</returns>
        public Boolean IsValid => Id != Guid.Empty && Name != String.Empty;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DomainObjectBase()
        {
            Id = Guid.NewGuid();
            Name = String.Empty;
            Description = String.Empty;
        }
    }
}

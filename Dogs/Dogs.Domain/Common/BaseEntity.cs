using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs.Domain.Common
{
    /// <summary>
    /// Represents a base entity class.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time the entity was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date and time the entity was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}

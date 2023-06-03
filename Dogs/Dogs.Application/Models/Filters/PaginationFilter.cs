using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs.Application.Models.Filters
{
    /// <summary>
    /// Represents a pagination filter for querying data.
    /// </summary>
    public class PaginationFilter
    {
        /// <summary>
        /// Gets or sets the offset value for pagination.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the size of each page in pagination.
        /// </summary>
        /// <remarks>
        /// The size should be between 1 and 50 (inclusive).
        /// The default value is 10.
        /// </remarks>
        [Range(1, 50)]
        public int PageSize { get; set; } = 10;
    }
}

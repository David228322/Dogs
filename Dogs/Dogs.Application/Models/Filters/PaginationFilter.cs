using System.ComponentModel.DataAnnotations;

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
        [Range(0, int.MaxValue)]
        public int PageNumber { get; set; } = 0;

        /// <summary>
        /// Gets or sets the size of each page in pagination.
        /// </summary>
        /// <remarks>
        /// The default value is 10.
        /// </remarks>
        [Range(1, int.MaxValue)]
        public int PageSize { get; set; } = 10;
    }
}

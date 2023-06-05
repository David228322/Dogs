namespace Dogs.Application.Models.Filters
{
    /// <summary>
    /// Represents a sorting and filtering option.
    /// </summary>
    public class SortFilter
    {
        /// <summary>
        /// Gets or sets the field to be sorted or filtered.
        /// </summary>
        public string Attribute { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the sorting or filtering should be in ascending order.
        /// </summary>
        public SortingOrder Order { get; set; }
    }
}

using Dogs.Application.Models.Filters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs.Application.Features.Dogs.Queries.GetDogsList
{
    /// <summary>
    /// Represents a query to retrieve a list of dogs.
    /// </summary>
    public class GetDogsListQuery : IRequest<IEnumerable<DogDto>>
    {
        /// <summary>
        /// Gets or sets the pagination filter for the query.
        /// </summary>
        public PaginationFilter PaginationFilter { get; set; }

        /// <summary>
        /// Gets or sets the sort filter for the query.
        /// </summary>
        public SortFilter SortFilter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDogsListQuery"/> class.
        /// </summary>
        /// <param name="paginationFilter">The pagination filter for the query.</param>
        /// <param name="sortFilter">The sort filter for the query.</param>
        public GetDogsListQuery(PaginationFilter paginationFilter, SortFilter sortFilter)
        {
            PaginationFilter = paginationFilter;
            SortFilter = sortFilter;
        }
    }
}

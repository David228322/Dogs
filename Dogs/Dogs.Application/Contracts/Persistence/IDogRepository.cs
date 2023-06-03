using Dogs.Application.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dogs.Application.Features.Dogs.Queries.GetDogsList;
using Dogs.Domain.Entities;

namespace Dogs.Application.Contracts.Persistence
{
    /// <summary>
    /// Represents a repository for managing dog entities.
    /// </summary>
    public interface IDogRepository : IGenericRepository<Dog>
    {
    }
}

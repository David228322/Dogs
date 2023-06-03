using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dogs.Application.Contracts.Persistence;

namespace Dogs.Application.Features.Dogs.Queries.GetDogsList
{
    internal class GetDogsListHandler : IRequestHandler<GetDogsListQuery, IEnumerable<DogDto>>
    {
        private readonly IDogRepository _dogRepository;
        private readonly IMapper _mapper;

        public GetDogsListHandler(IDogRepository dogRepository, IMapper mapper)
        {
            _dogRepository = dogRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DogDto>> Handle(GetDogsListQuery request, CancellationToken cancellationToken)
        {
            var orders = await _dogRepository.GetFilteredAsync(request.PaginationFilter, request.SortFilter);
            var result = _mapper.Map<IEnumerable<DogDto>>(orders);
            return result;
        }
    }
}

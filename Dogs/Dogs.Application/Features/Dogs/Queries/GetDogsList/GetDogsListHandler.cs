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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetDogsListHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DogDto>> Handle(GetDogsListQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.DogRepository.GetFilteredAsync(request.PaginationFilter, request.SortFilter);
            var dogs = _mapper.Map<IEnumerable<DogDto>>(orders);
            return dogs;
        }
    }
}

using MediatR;
using AutoMapper;
using Dogs.Application.Contracts.Persistence;

namespace Dogs.Application.Features.Dogs.Queries.GetDogsList
{
    /// <summary>
    /// Handler for the <see cref="GetDogsListQuery"/> query.
    /// </summary>
    public class GetDogsListHandler : IRequestHandler<GetDogsListQuery, IEnumerable<DogDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDogsListHandler"/> class.
        /// </summary>
        /// <param name="mapper">The <see cref="IMapper"/>.</param>
        /// <param name="unitOfWork">The <see cref="IUnitOfWork"/>.</param>
        public GetDogsListHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<DogDto>> Handle(GetDogsListQuery request, CancellationToken cancellationToken)
        {
            var dogs = await _unitOfWork.DogRepository.GetFilteredAsync(request.PaginationFilter, request.SortFilter);
            var dogDtos = _mapper.Map<IEnumerable<DogDto>>(dogs);
            return dogDtos;
        }
    }
}

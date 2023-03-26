using Application.Interfaces;
using AutoMapper;

namespace Application.Handler
{
    public sealed class Handler : IHandler
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;
        private readonly IMovieClient _movieClient;

        public Handler(IMovieClient movieClient, IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
            _movieClient = movieClient;
        }
    }
}

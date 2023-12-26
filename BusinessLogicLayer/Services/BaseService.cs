using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services
{
    public abstract class BaseService<T> where T : BaseEntity
    {
        protected readonly IMapper _mapper;
        protected readonly IBaseRepository<T> _repository;

        protected BaseService(IMapper mapper, IBaseRepository<T> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
    }
}

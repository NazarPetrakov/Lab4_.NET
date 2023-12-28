using AutoMapper;
using BusinessLogicLayer.DTOs.Dialog;
using BusinessLogicLayer.DTOs.Relationship;
using BusinessLogicLayer.DTOs.User;
using BusinessLogicLayer.Exeptions;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IBaseRepository<Dialog> _dialogRepository;
        private readonly IBaseRepository<Relationship> _relationshipRepository;
        public UserService(IMapper mapper, 
            IBaseRepository<User> repository,
            IBaseRepository<Dialog> dialogRrepository, 
            IBaseRepository<Relationship> relationshipRepository) 
            : base(mapper, repository)
        {
            _dialogRepository = dialogRrepository;
            _relationshipRepository = relationshipRepository;
        }
        public async Task<ICollection<UserGetDto> > GetAll()
        {
            var users = await _repository.GetAllAsync();
            var userDtos = new List<UserGetDto>();

            foreach (var user in users)
            {
                var dto = _mapper.Map<UserGetDto>(user);
                dto.FriendsCount = await FriendsCount(user.Id);
                userDtos.Add(dto);
            }

            return userDtos;
        }

        public async Task<UserGetDto> GetById(long id)
        {
            var user = await _repository.GetByIdAsync(id) ?? throw new EntityNotFoundException<User>(id);
            var userDto = _mapper.Map<UserGetDto>(user);
            userDto.FriendsCount = await FriendsCount(id);

            return userDto;
        }

        public async Task<ICollection<DialogGetDto>> GetDialogsByUserId(long id)
        {
            var userDialogs = await _dialogRepository.GetManyWithFilterAsync(d => d.UserId == id);
            var dialogDtos = new List<DialogGetDto>();

            foreach (var dialog in userDialogs)
            {
                var dto = _mapper.Map<DialogGetDto>(dialog);
                dialogDtos.Add(dto);
            }

            return dialogDtos;
        }

        public async Task<ICollection<RelationshipGetDto>> GetRelationshipsByUserId(long id)
        {
            var userRelationships = await _relationshipRepository.GetManyWithFilterAsync(r => r.UserId == id);
            var relationshipDtos = new List<RelationshipGetDto>();

            foreach (var relationship in userRelationships)
            {
                var dto = _mapper.Map<RelationshipGetDto>(relationship);
                relationshipDtos.Add(dto);
            }

            return relationshipDtos;
        }
        private async Task<int> FriendsCount(long id)
        {
            var userRelationships = await GetRelationshipsByUserId(id);
            int friendsCount = userRelationships.Count(r => r.Status == "active");

            return friendsCount;
        }
    }
}

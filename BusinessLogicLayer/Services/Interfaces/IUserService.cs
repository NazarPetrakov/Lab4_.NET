using BusinessLogicLayer.DTOs.Dialog;
using BusinessLogicLayer.DTOs.Relationship;
using BusinessLogicLayer.DTOs.User;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserGetDto> GetById(long id);
        Task<ICollection<UserGetDto>> GetAll();
        Task<ICollection<RelationshipGetDto>> GetRelationshipsByUserId(long id);
        Task<ICollection<DialogGetDto>> GetDialogsByUserId(long id);
    }
}

using BusinessLogicLayer.DTOs.Relationship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IRelationshipService
    {
        Task AddFriendRequest(RelationshipAddDto dto); //outcoming
        Task AddReceiveFriendRequest(RelationshipAddDto dto); //incoming
        Task AcceptFriendRequest(RelationshipUpdateDto dto);
        Task DeclineFriendRequest(RelationshipUpdateDto dto);
        Task Delete(long id);
        Task<RelationshipGetDto> GetById(long id);
        Task<ICollection<RelationshipGetDto>> GetAll();
    }
}

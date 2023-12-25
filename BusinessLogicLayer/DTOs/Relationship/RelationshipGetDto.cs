using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs.Relationship
{
    public class RelationshipGetDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long FriendId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

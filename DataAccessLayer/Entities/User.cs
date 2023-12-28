namespace DataAccessLayer.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Message> Messages { get; set; } = new List<Message>();
        public ICollection<Dialog> Dialogs { get; set; } = new List<Dialog>();
        public ICollection<Relationship> Relationships { get; set; } = new List<Relationship>();

    }
}

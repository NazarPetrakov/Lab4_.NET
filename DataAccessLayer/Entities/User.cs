using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Message> Messages { get; set; } = new List<Message>();
        public ICollection<Dialog> Dialogs { get; set; } = new List<Dialog>();
        public ICollection<Relationship> Relationships { get; set; } = new List<Relationship>();

    }
}

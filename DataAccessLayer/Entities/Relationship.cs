using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Relationship : BaseEntity
    {
        public long UserId { get; set; }
        public long FriendId { get; set; }
        public string Status { get; set; }
    }
}

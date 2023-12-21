using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Message : BaseEntity
    {
        public long UserId { get; set; }
        public long FriendId { get; set; }
        public long DialogId { get; set; }
        public string Content { get; set; }
        public DateTime SentDateTime { get; set; }
    }
}

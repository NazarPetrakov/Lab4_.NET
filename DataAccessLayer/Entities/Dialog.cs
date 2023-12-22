﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Dialog : BaseEntity
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long FriendId { get; set; }
        public User Friend { get; set; }
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}

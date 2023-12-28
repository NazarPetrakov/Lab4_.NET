﻿namespace BusinessLogicLayer.DTOs.User
{
    public class UserGetDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int FriendsCount { get; set; }
        public DateTime DateOfBirth { get; set; }
        
    }
}

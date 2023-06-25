﻿namespace FOA.BACKEND.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public string Title { get; set; }
        public string Message { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bright.Models
{
    public class Idea
    {
        [Key]
        public int IdeaId { get; set; }
    
        public string Description { get; set; }

        public int UserId { get; set; }
        
        public User User { get; set; }

        public List<UserIdea> UserIdeas { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
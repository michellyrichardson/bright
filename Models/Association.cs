using System;
using System.ComponentModel.DataAnnotations;

namespace Bright.Models
{
    public class UserIdea
    {
        [Key]
        public int UserIdeaId { get; set; }

        public int IdeaId { get; set; }
        public Idea Idea { get; set; }

        [Display(Name="User: ")]
        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
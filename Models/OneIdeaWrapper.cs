using System.Collections.Generic;

namespace Bright.Models
{
    public class OneIdeaWrapper
    {
        public int LoggedId { get; set; }
        public User LoggedUser { get; set; }
        public Idea Idea { get; set; }
        public UserIdea AddIdeaForm { get; set; }
        public List<Idea> AllIdea { get; set; }
        public List<User> AllUsers { get; set; }
        
    }
}
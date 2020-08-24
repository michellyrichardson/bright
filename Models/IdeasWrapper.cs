using System.Collections.Generic;

namespace Bright.Models
{
    public class IdeasWrapper
    {
        public User LoggedUser { get; set; }
        public Idea Idea { get; set; }
        public UserIdea AddIdeaForm { get; set; }
        public List<Idea> AllIdeas { get; set; }
    }
}
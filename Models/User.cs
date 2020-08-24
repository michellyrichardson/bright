using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bright.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        

        [Required(ErrorMessage="Name is required.")]
        [MinLength(2, ErrorMessage="First name must be at least 2 characters.")]
        [Display(Name="Name: ")]
        public string Name { get; set; }

        [Required(ErrorMessage="Alias is required.")]
        [Display(Name="Alias: ")]
        public string Alias { get; set; }

        [Required(ErrorMessage="Email address is required.")]
        [EmailAddress(ErrorMessage="Invalid email address.")]
        [Display(Name="Email: ")]
        public string Email { get; set; }

        [Required(ErrorMessage="Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name="Password: ")]
        
        public string Password { get; set; }

        [Required(ErrorMessage="Confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name="Confirm: ")]
        [Compare("Password", ErrorMessage="Please ensure that your passwords match.")]
        [NotMapped]
        public string Confirm { get; set; }

        
        public List<Idea> Ideas { get; set; }
        public List<UserIdea> UserIdeas { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
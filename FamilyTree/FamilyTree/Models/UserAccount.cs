using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTree.Models
{
    public class UserAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]

        public int UserId { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LasttName { get; set; }


        public string Email { get; set; }
        
        public string Password { get; set; }


        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }    
    }
}
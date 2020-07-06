using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evolent.WebApp.Models
{
    public class ContactModel
    {
        public int Customer_Id { get; set; }
        [Display(Name = "First Name")]
        public string First_Name { get; set; }
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        [Display(Name = "Email")]
        public string Email_Id { get; set; }
        [Display(Name = "Contact")]
        public string Phone_Number { get; set; }
        public Status Status { get; set; }

    }
    public enum Status
    {
        Active,
        InActive
    }
}

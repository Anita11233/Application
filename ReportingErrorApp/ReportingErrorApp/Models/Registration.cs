namespace ReportingErrorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Helpers;

    [Table("Registration")]
    public partial class Registration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        // Name
        [Required(ErrorMessage = "This field is required.")]
        public string UserName { get; set; }

        // Email
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [DisplayName("E-Mail")]
        public string eMail { get; set;}

        // LastName
        public string Name { get; set; }

        // Password
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        // Confirm Password
        [Required(ErrorMessage = "Confirm password")]
        [Compare("Password")]
        [DisplayName ("Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Adress { get; set; }

        public string Contact { get; set; }
        public object Phone { get; internal set; }
    }
}

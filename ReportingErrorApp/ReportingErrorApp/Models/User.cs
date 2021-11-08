namespace ReportingErrorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Helpers;

    [Table("User")]
    public partial class User
    {
        public int Id { get; set; }
        // Username
        [Required(ErrorMessage = "This field is required.")]
        public string Username { get; set; }

        // Password
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // Confirm Password
        [Required(ErrorMessage = "Confirm password")]
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
namespace ReportingErrorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Helpers;

    [Table("Dashboard")]

    public partial class Dashboard
    {
        public int Id { get; set; }

        [DisplayName("Client Name")]
        public string ClientName { get; set; }

        // Priority
        public string Priority { get; set; }



        [DisplayName("Request Type")]
        public string RequestType { get; set; }


        public string Description { get; set; }



        [DisplayName("Contract")]
        public string Contract { get; set; }


        public string Phone { get; set; }

        // Date Created
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DateCreated { get; set; } = DateTime.Now;



        [DisplayName("Assign User")]
        [DisplayFormat(NullDisplayText ="Add user for this task")]
        public string AssignUser { get; set; }
        


    


        /*        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "NULL")]

          public DateTime RequestTime { get; set; } */

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //[Min18YearsIfAMember]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public int MembershipTypeId { get; set; }

    }
}
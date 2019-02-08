using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vodly.Models;

namespace Vodly.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(200)]
        public string Name { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }

        public bool IsSubscribeToNewsLetter { get; set; }

        public byte MemberShipTypeId { get; set; }
    }
}
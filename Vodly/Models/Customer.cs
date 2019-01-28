using System;
using System.ComponentModel.DataAnnotations;

namespace Vodly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(200)]
        public string Name { get; set; }
        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
        public bool IsSubscribeToNewsLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }
        [Display(Name="Member Ship Type")]
        public byte MemberShipTypeId { get; set; }
    }
}
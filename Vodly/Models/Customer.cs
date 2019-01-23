using System;
using System.ComponentModel.DataAnnotations;

namespace Vodly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public bool IsSubscribeToNewsLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }
        [Display(Name="Membar Ship Type")]
        public byte MemberShipTypeId { get; set; }
    }
}
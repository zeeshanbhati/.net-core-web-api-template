using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EFTemplate.Request
{
    public class CreateStationRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public decimal Pricing { get; set; }
        [Required]
        public string ImageURL { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace AirlineManagementSystem.Models
{
    public partial class Airline
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid First Name")]
        public string Name { get; set; }
    }
}

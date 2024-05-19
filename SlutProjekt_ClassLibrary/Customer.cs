using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ClassModels
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [IgnoreDataMember]
        public ICollection<Appointment> Appointments { get; set; }

    }
}

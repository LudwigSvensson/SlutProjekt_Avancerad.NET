
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ClassModels
{
    public class Appointment
    {
        [Key]
        public int ApointmentID { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }

        public DateTime AppointmentDate { get; set; }
        [JsonIgnore]
        public int CustomerID { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        public int CompanyID { get; set; }
        [JsonIgnore]
        public Company Company { get; set; }
    }
}

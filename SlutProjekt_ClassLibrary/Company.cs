using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClassModels
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }


        public ICollection<Appointment> Appointments { get; set; }

    }
}

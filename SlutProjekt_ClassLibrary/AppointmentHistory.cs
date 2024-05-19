using ClassModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutProjekt_ClassLibrary
{
    public class AppointmentHistory
    {
        [Key]
        public int AppointmentHistoryID { get; set; }
        public int AppointmentID { get; set; }
        [Required]
        public string Action { get; set; }
        [Required]
        public DateTime ActionTimeStamp { get; set; }
        [Required]
        public string OldData { get; set; }
        public string NewData { get; set; }

    }
}

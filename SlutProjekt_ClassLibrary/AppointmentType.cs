using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    public enum AppointmentType
    {
        [EnumMember(Value = "Carservice")]
        Carservice = 0,
        [EnumMember(Value = "Carwash")]
        Carwash = 1,
        [EnumMember(Value = "Inside car cleaning")]
        example = 2,
    }
}

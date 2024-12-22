using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.Backend.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public DayOfWeek Day { get; set; }
        public bool Active { get; set; }
        public string Name 
        {
            get 
            { 
                return Day.ToString() + " (" + StartTime.ToShortTimeString() + "-" + EndTime.ToShortTimeString() + ")";
            } 
        }
    }
}
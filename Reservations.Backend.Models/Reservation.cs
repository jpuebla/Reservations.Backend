using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.Backend.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int TableId { get; set; }
        public RestaurantTable? Table { get; set; }
        public int ShiftId { get; set; }
        public Shift? Shift { get; set; }
        public DateOnly ReservationDay { get; set; }
        public int People { get; set; }
        public string Description 
        { 
            get 
            {
                string desc = Name;
                
                if (Table != null)
                { 
                desc = desc + " - table: " + Table.Name;
                }

                if (Shift != null)
                {
                    desc = desc + " - shift: " + Shift.Name;
                }

                return desc + " (" + People.ToString() + " p.)";
            } 
        }
    }
}
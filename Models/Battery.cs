using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Battery
    {
        public int id { get; set; }
        public string building_type { get; set; }
        public string status { get; set; }
        public DateTime date_of_commissioning { get; set; }
        public DateTime date_of_last_inspection { get; set; }
        public string certificate_of_operations { get; set; }
        public string information { get; set; }
        public string notes { get; set; }
        public int employee_id { get; set; }
        public int building_id { get; set; }
        public List<Column> columns { get; set; }
        public Building building { get; set; }
    }
}
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


// BATTERY TABLE from the schema of the Ruby on Rails's base project
/* create_table "batteries", options: "ENGINE=InnoDB DEFAULT CHARSET=utf8", force: :cascade do | t |
    t.string "building_type"
    t.string "status"
    t.date "date_of_commissioning"
    t.date "date_of_last_inspection"
    t.string "certificate_of_operations"
    t.string "information"
    t.text "notes"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.bigint "employee_id"
    t.bigint "building_id"
    t.index["building_id"], name: "index_batteries_on_building_id"
    t.index["employee_id"], name: "index_batteries_on_employee_id"
  end */
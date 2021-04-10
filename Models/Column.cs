using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Column
    {
        public int id { get; set; }
        public string building_type { get; set; }
        public int number_of_floors_serve { get; set; }
        public string status { get; set; }
        public string information { get; set; }
        public string notes { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int battery_id { get; set; }
        public List<Elevator> elevators { get; set; }
        public Battery battery { get; set; }
    }
}


// COLUMN TABLE from the schema of the Ruby on Rails's base project
/* create_table "columns", options: "ENGINE=InnoDB DEFAULT CHARSET=utf8", force: :cascade do | t |
    t.string "building_type"
    t.integer "number_of_floors_served"
    t.string "status"
    t.string "information"
    t.text "notes"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.bigint "battery_id"
    t.index["battery_id"], name: "index_columns_on_battery_id"
  end */
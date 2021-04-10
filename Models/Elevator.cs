using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Elevator
    {
        public int id { get; set; }
        public string serial_number { get; set; }
        public string model { get; set; }
        public string building_type { get; set; }
        public string status { get; set; }
        public DateTime date_of_commissioning { get; set; }
        public DateTime date_of_last_inspection { get; set; }
        public string certificate_of_inspection { get; set; }
        public string information { get; set; }
        public string notes { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int column_id { get; set; }
        public Column column { get; set; }
    }
}


// ELEVATOR TABLE from the schema of the Ruby on Rails's base project
/* create_table "elevators", options: "ENGINE=InnoDB DEFAULT CHARSET=utf8", force: :cascade do |t|
    t.string "serial_number"
    t.string "model"
    t.string "building_type"
    t.string "status"
    t.date "date_of_commissioning"
    t.date "date_of_last_inspection"
    t.string "certificate_of_inspection"
    t.string "information"
    t.text "notes"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.bigint "column_id"
    t.index ["column_id"], name: "index_elevators_on_column_id"
  end */
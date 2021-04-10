using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string title { get; set; }
        public string email { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int user_id { get; set; }
    }
}


// EMPLOYEE TABLE from the schema of the Ruby on Rails's base project
/* create_table "employees", options: "ENGINE=InnoDB DEFAULT CHARSET=utf8", force: :cascade do | t |
    t.string "first_name"
    t.string "last_name"
    t.string "title"
    t.string "email"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.bigint "user_id"
    t.index["user_id"], name: "index_employees_on_user_id"
  end */
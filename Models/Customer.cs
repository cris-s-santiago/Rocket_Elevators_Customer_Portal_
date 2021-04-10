using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string company_name { get; set; }
        public string full_name_of_company_contact { get; set; }
        public string company_contact_phone { get; set; }
        public string email_of_company_contact { get; set; }
        public string company_description { get; set; }
        public string full_name_of_service_technical_authority { get; set; }
        public string technical_authority_phone_for_service_ { get; set; }
        public string technical_manager_email_for_service { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int user_id { get; set; }
        public int address_id { get; set; }
        public List<Building> buildings { get; set; }
    }
}


// CLIENT TABLE from the schema of the Ruby on Rails's base project
/* create_table "customers", options: "ENGINE=InnoDB DEFAULT CHARSET=utf8", force: :cascade do | t |
    t.date "customers_creation_date"
    t.string "company_name"
    t.string "full_name_of_company_contact"
    t.string "company_contact_phone"
    t.string "email_of_company_contact"
    t.text "company_description"
    t.string "full_name_of_service_technical_authority"
    t.string "technical_authority_phone_for_service_"
    t.string "technical_manager_email_for_service"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.bigint "user_id"
    t.bigint "address_id"
    t.index["address_id"], name: "index_customers_on_address_id"
    t.index["user_id"], name: "index_customers_on_user_id"
  end */

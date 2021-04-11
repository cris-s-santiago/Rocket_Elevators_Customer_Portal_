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

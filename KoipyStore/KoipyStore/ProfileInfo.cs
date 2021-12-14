using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;

namespace KoipyStore
{
    public class ProfileInfo
    {
        //public enum enumStatus { STATUS_INVALID = -1, STATUS_VALID=1}
        public string status;
	    public string description;
        public string total_perk;
        public string total_perk_without_last_visit;
        public string default_people_no;
        public string default_spending;

        public string default_extra_point;
        public string status_bar;
        public string max_average_spending_per_person;

        public Visit visit = new Visit();
        public Profile profile = new Profile();
        public ArrayList promotions = new ArrayList();
        public ArrayList koipyButtons = new ArrayList();

        public int show_xp = 1;
        public int show_invoice = 1;

        public void Clear()
        {
            status = "";
            description = "";
            total_perk = "";
            total_perk_without_last_visit = "";
            default_people_no = "";
            default_spending = "";
            default_extra_point = "";
            status_bar = "";
            max_average_spending_per_person = "";
            this.visit.Clear();
            this.profile.Clear();
            this.promotions.Clear();
            this.koipyButtons.Clear();
        }
    }

    public class Visit
    {
        public string id;
        public string created;
        public string spending;
        public string perk;
        public string status;
        public string people_no;
        public string invoice_no;
        public string variable;
        public string modified;
        public string profile_id;
        public string store_id;
        public string branch_id;
        public string score;
        public string review;

        public void Clear()
        {
            id = null;
            created = "";
            spending = "";
            perk = "";
            status = "";
            people_no = "";
            invoice_no = "";
            variable = "";
            modified = "";
            profile_id = "";
            store_id = "";
            branch_id = "";
            score = "";
            review = "";

        }
    }

    public class Profile
    {
        public string id;
        public string name;
        public string gender;
        public string username;
        public string prefered_to_be_called;
        public string mobile;
        public string dob;
        public string note;

        public void Clear()
        {
            id = "";
            name = "";
            gender = "";
            username = "";
            prefered_to_be_called = "";
            mobile = "";
            dob = "";
            note = "";
        }
    }

    public class Promotion
    {
        public string id;
        public string name;
        public string condition;
        public string thumbnail;
        public string status;
        public string perk;
        public string created;
        public string modified;
        public string redemption_quantity;

        public void Clear()
        {
            id = "";
            name = "";
            condition = "";
            thumbnail = "";
            status = "";
            perk = "";
            created = "";
            modified = "";
            redemption_quantity = "";
        }
    }

    public class KoipyButton
    {
        public string enabled;
        public string text;
        public string url;

        public void Clear()
        {
            enabled = "";
            text = "";
            url = "";
        }
    }


}

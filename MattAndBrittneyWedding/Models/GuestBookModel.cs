using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MattAndBrittneyWedding.Models
{
    public class GuestBookModel
    {
        public int GuestBookID { get; set; }

        public String Message { get; set; }

        public String Email { get; set; }

        public String Name { get; set; }        

        public String Injected { get; set; }

        public bool IsVisible { get; set; }

        public bool IsDeleted { get; set; }
    }
}
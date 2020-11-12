using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Slijterij_Sjonnie_Loper.Data
{
    public class Staff : IdentityUser
    {
        [PersonalData]
        public string Firstname { get; set; }
        [PersonalData]
        public string Middlename { get; set; }
        [PersonalData]
        public string Lastname { get; set; }
        [PersonalData]
        public string fullname { get; set; }
        [PersonalData]
        public string Role { get; set; }
    }

    //public enum status
    //{
    //    StaffMember, Client
    //}

}

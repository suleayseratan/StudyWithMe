using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StudyWithMe.WebUI.Identity
{
    public class User : IdentityUser
    {
        // Kullanıcının adı, soyadı, doğrum tarihi gibi özellikleri bu class'da tanımlanır.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsBroadcaster { get; set; }
        public bool IsFirstLogin { get; set; } = true;
    }
}
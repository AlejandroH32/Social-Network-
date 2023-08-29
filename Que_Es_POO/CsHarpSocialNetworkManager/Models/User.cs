using CsHarpSocialNetworkManager.Utilitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHarpSocialNetworkManager.Models
{
    internal class User
    {

        public string Name { get; set; }


        public string Email { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime dateCreated { get; set; } = DateTime.Now;

        public short Age { get; set; }

        public bool IsValid(bool validateAge = true)
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty (Email) || !HelperValidate.isValidEmail(Email)) 
                return false;

            if (( Age < 0 || Age > 250) && validateAge)
                return false;

            return true;

        }

       

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHarpSocialNetworkManager.Models
{
    internal class SocialsNetwork
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public List<User> users { get; set; }

       public DateTime DateCreade { get; set; }

       
    }
}

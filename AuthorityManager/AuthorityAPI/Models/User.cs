using System.Collections.Generic;

namespace AuthorityAPI.Models
{
    public class User
    {
        public string UserName { get; set; }
        public List<string> PageNames { get; set; }
    }
}

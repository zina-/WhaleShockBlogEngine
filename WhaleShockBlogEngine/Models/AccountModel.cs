using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhaleShockBlogEngine.Models
{
    [Serializable]
    public class AccountModel
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WhaleShockBlogEngine.Models
{
    [Serializable]
    public class AccountModel
    {
        public string Hash_Id { get; set; }
        public string Hash_Password { get; set; }
        internal string Id { get; set; }
        internal string Password { get; set; }

        public bool GetIdVaildation()
        {
            // 3자리 이상, 12자리 이하
            // 숫자 및 영문자
            string idPattern = @"^[a-zA-Z][a-zA-Z0-9]{2,11}$";
            return Regex.Match(Hash_Id, idPattern).Success;
        }
        public bool GetPasswordValidation()
        {
            // 8자리 이상, 20자리 이하
            string passwordPattern = @"^[\w\S\d]{8,20}$";
            return Regex.Match(Hash_Password, passwordPattern).Success;
        }
    }
}
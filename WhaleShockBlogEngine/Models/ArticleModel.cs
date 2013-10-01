using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhaleShockBlogEngine.Models
{
    [Serializable]
    public class ArticleModel
    {
        public string Subject { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string Writer { get; set; }
        public string Content { get; set; }
    }
}
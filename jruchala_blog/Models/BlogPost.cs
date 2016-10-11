using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jruchala_blog.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public BlogPost()
        {
            this.Comments = new HashSet<Comment>();
        }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string MediaUrl { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
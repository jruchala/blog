﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jruchala_blog.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public BlogPost()
        {
            this.Comments = new HashSet<Comment>();
        }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Updated { get; set; }
        public string Title { get; set; }

        [AllowHtml]
        public string Body { get; set; }
        [Display(Name="Image")]
        [DataType(DataType.Upload)]
        public string MediaUrl { get; set; }

        public string Slug { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
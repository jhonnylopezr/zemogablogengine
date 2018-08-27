using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZemogaBlogEngine.Entities
{
    public class PostComment
    {
        public PostComment()
        {
            this.CreatedOn = DateTime.Now;
        }
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}

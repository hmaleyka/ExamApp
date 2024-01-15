using ExamApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Core.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
    }
}

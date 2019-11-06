using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebCore.Models
{
    public class QuestionsHeaderContent
    {
        [Key]
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebCore.Models
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }

        public string Question { get; set; }
        public string QuestionAnswerA { get; set; }
        public string QuestionAnswerB { get; set; }
        public string QuestionAnswerC { get; set; }
        public string QuestionAnswerD { get; set; }

        public string TrueAnswer { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int HeaderId { get; set; }
    }
}

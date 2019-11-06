using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebCore.Models
{
    public interface ILoginRepository
    {
        IQueryable<Login> Logins { get; }    
        IQueryable<QuestionsHeaderContent> content { get; set; }
        IQueryable<Questions> question { get; set; }
        
        void CreateLogin(Login login);
        void SaveQuestionHeaderContent(QuestionsHeaderContent questions);

        void QuestionAnswer(Questions questions);

        void Delete(int questionId);
    }
}

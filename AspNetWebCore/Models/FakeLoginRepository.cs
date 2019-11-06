using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebCore.Models
{
    public class FakeLoginRepository : ILoginRepository
    {
        public IQueryable<Login> Logins => new List<Login> { 
        
        }.AsQueryable();

        public IQueryable<QuestionsHeaderContent> content { get => new List<QuestionsHeaderContent> { }.AsQueryable(); set => new List<QuestionsHeaderContent> { }.AsQueryable(); }
        public IQueryable<Questions> question { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void CreateLogin(Login login)
        {
            throw new NotImplementedException();
        }

        public void Delete(int questionId)
        {
            throw new NotImplementedException();
        }

        public void QuestionAnswer(Questions questions)
        {
            throw new NotImplementedException();
        }

        public void SaveQuestionHeaderContent(QuestionsHeaderContent questions)
        {
            throw new NotImplementedException();
        }
    }
}

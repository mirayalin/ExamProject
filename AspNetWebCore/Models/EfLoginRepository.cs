using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebCore.Models
{
    public class EfLoginRepository : ILoginRepository
    {
        private ApplicationDbContext _context;
        public EfLoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Login> Logins => _context.Logins;

        public IQueryable<QuestionsHeaderContent> questionContent => _context.questionsHeaderContents;

        public IQueryable<QuestionsHeaderContent> content { get => new List<QuestionsHeaderContent> { }.AsQueryable(); set => new List<QuestionsHeaderContent> { }.AsQueryable(); }
        public IQueryable<Questions> question { get => _context.questions; set => new List<Questions> { }.AsQueryable(); }
        IQueryable<QuestionsHeaderContent> ILoginRepository.content { get => _context.questionsHeaderContents; set => _context.questionsHeaderContents.ToList(); }

        public void CreateLogin(Login login)
        {

            _context.Logins.Add(login);
            _context.SaveChanges();
        }
        public void Delete(int questionId)
        {
            var question = GetById(questionId);

            if (question != null)
            {
                _context.questions.Remove(question);
                _context.SaveChanges();
            }
        }

        public Questions GetById(int questionId)
        {
            return _context.questions.FirstOrDefault(i => i.Id == questionId);
        }

        public void QuestionAnswer(Questions questions)
        {
            _context.questions.Add(questions);
            _context.SaveChanges();
        }

        public void SaveQuestionHeaderContent(QuestionsHeaderContent questions)
        {
            _context.questionsHeaderContents.Add(questions);
            _context.SaveChanges();
        }
    }
}

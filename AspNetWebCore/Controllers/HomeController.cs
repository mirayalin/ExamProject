using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetWebCore.Models;
using System.Xml;
using System.ServiceModel.Syndication;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetWebCore.Controllers
{
    public class HomeController : Controller
    {
        private ILoginRepository repository;

        public HomeController(ILoginRepository _repository)
        {
            repository = _repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult List() => View(repository.Logins);

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tumListe = repository.Logins.ToList();
                var kullanıcıBilgisi = repository.Logins.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
                if (kullanıcıBilgisi != null)
                {
                    return RedirectToAction("DondurulecekSayfa");
                }
                else
                {
                    return View(model);
                }
            }

            return View(model);
        }
        public ActionResult DondurulecekSayfa()
        {
            var baslikTablosu = repository.question.ToList();
            List<RssListesi> summaryText = new List<RssListesi>();

            if (baslikTablosu.Count() == 0)
            {

                string url = "http://www.wired.com/feed";
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                var dd = feed.Items.OrderByDescending(x => x.PublishDate).Take(5);
                int count = 0;
                var getAllListOfHeader = repository.content.ToList();
                foreach (SyndicationItem item in feed.Items.OrderByDescending(x => x.PublishDate).Take(5))
                {
                    QuestionsHeaderContent totalValues = new QuestionsHeaderContent();

                    count++;
                    if (item.Title.Text != null && item.Summary.Text != null)
                    {
                        var dddd = repository.content.Where(x => x.Header != item.Title.Text).FirstOrDefault();
                        if (dddd != null)
                        {
                            summaryText.Add(new RssListesi
                            {
                                Id = count,
                                Text = item.Title.Text,
                                Summary = item.Summary.Text
                            });

                            totalValues.Header = item.Title.Text;
                            totalValues.Content = item.Summary.Text;
                            repository.SaveQuestionHeaderContent(totalValues);

                        }
                        else
                        {
                            if (dddd == null)
                            {
                                summaryText.Add(new RssListesi
                                {
                                    Id = count,
                                    Text = item.Title.Text,
                                    Summary = item.Summary.Text
                                });

                                totalValues.Header = item.Title.Text;
                                totalValues.Content = item.Summary.Text;
                                repository.SaveQuestionHeaderContent(totalValues);
                            }

                        }
                    }

                }
            }
            ViewBag.SelectedListHeader = SorulariGetir();
            return View(summaryText);

        }
        [HttpPost]
        public JsonResult ContentView(string valueOfHeader)
        {
            var convertHeader = Convert.ToInt32(valueOfHeader);
            var Content = repository.content.Where(x => x.Id == convertHeader).Select(x => x.Content).FirstOrDefault();
            return Json(new { Result = "OK", Content });
        }
        [HttpPost]
        public IActionResult SaveQuestions(FormContain formContain)
        {
            try
            {
                if (formContain.firstQuestion != null)
                {
                    Questions questions = new Questions();
                    questions.Question = formContain.firstQuestion;
                    questions.QuestionAnswerA = formContain.firstAnswer;
                    questions.QuestionAnswerB = formContain.secondQuestion;
                    questions.QuestionAnswerC = formContain.thirdAnswer;
                    questions.QuestionAnswerD = formContain.fourAnswer;
                    questions.TrueAnswer = formContain.firstQuestionAnswer;

                    questions.KayitTarihi = DateTime.Now;
                    questions.HeaderId = Convert.ToInt32(formContain.QuestionHeaderId);

                    repository.QuestionAnswer(questions);
                }
                if (formContain.secondQuestion != null)
                {
                    Questions questions = new Questions();

                    questions.Question = formContain.secondQuestion;
                    questions.QuestionAnswerA = formContain.fiveAnswer;
                    questions.QuestionAnswerB = formContain.sixAnswer;
                    questions.QuestionAnswerC = formContain.sevenAnswer;
                    questions.QuestionAnswerD = formContain.eightAnswer;
                    questions.TrueAnswer = formContain.secondQuestionAnswer;
                    questions.KayitTarihi = DateTime.Now;
                    questions.HeaderId = Convert.ToInt32(formContain.QuestionHeaderId);
                    repository.QuestionAnswer(questions);
                }
                if (formContain.thirdQuestion != null)
                {
                    Questions questions = new Questions();

                    questions.Question = formContain.thirdQuestion;
                    questions.QuestionAnswerA = formContain.nineAnswer;
                    questions.QuestionAnswerB = formContain.tenAnswer;
                    questions.QuestionAnswerC = formContain.elevenAnswer;
                    questions.QuestionAnswerD = formContain.twelveAnswer;
                    questions.TrueAnswer = formContain.thirdhQuestionAnswer;
                    questions.KayitTarihi = DateTime.Now;
                    questions.HeaderId = Convert.ToInt32(formContain.QuestionHeaderId);
                    repository.QuestionAnswer(questions);
                }
                if (formContain.forthQuestion != null)
                {
                    Questions questions = new Questions();

                    questions.Question = formContain.forthQuestion;
                    questions.QuestionAnswerA = formContain.thirteenAnswer;
                    questions.QuestionAnswerB = formContain.fourteenAnswer;
                    questions.QuestionAnswerC = formContain.fifteenAnswer;
                    questions.QuestionAnswerD = formContain.sixteenAnswer;
                    questions.TrueAnswer = formContain.fourthQuestionAnswer;
                    questions.KayitTarihi = DateTime.Now;
                    questions.HeaderId = Convert.ToInt32(formContain.QuestionHeaderId);
                    repository.QuestionAnswer(questions);
                }
                return RedirectToAction("ListOfQuestions");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public IActionResult ListOfQuestions()
        {
            List<QuestionHeaderName> questions = new List<QuestionHeaderName>();

            try
            {
                var soruIDs = from m in repository.question orderby m.HeaderId group m by m.HeaderId into grup select new { id = grup.Key, Header = grup.ToList() };
                foreach (var item in soruIDs)
                {
                    var baslikicerikleri = (from m in repository.content where m.Id == item.id select m.Content).FirstOrDefault();
                    var tarih = (from m in repository.question where m.HeaderId == item.id select m.KayitTarihi).FirstOrDefault();
                    questions.Add(new QuestionHeaderName
                    {
                        Id = item.id,
                        HeaderName = baslikicerikleri,
                        Tarih = tarih
                    });
                }
                return View(questions);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }
        [HttpGet]
        public IActionResult SorulariTamamla(int id)
        {
            var sorular = repository.question.Where(x => x.HeaderId == id).ToList();
            return View(sorular);
        }

        [HttpGet]
        public JsonResult RightAnswer(string HeaderValue)
        {
            int headerID = Convert.ToInt32(HeaderValue);
            var answerQuestions = repository.question.Where(m => m.HeaderId == headerID).ToList();
            return Json(new { Result = "OK", answerQuestions });
        }
        [HttpGet]
        public JsonResult FindValueOfId(string HeaderValue)
        {
            int headerID = Convert.ToInt32(HeaderValue);
            var answerQuestions = repository.question.Where(m => m.Id == headerID).FirstOrDefault();
            return Json(new { Result = "OK", answerQuestions });
        }
        public List<SelectListItem> SorulariGetir()
        {
            try
            {

                var headerList = (from c in repository.content orderby c.Id select new SelectListItem { Text = c.Header.ToString(), Value = c.Id.ToString() }).OrderByDescending(x => x.Value).Take(5).ToList();
                //gib.Dispose();
                return headerList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("ListOfQuestions");
        }
        public class QuestionHeaderName
        {
            public int Id { get; set; }
            public string HeaderName { get; set; }
            public DateTime Tarih { get; set; }
        }
        public class RssListesi
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public string Summary { get; set; }
            //public List<FormContain> formContain { get; set; }
        }


        public class FormContain
        {
            public int HeaderId { get; set; }
            public DateTime KayitTarihi { get; set; }
            public int QuestionHeaderId { get; set; }
            public string firstQuestion { get; set; }
            public string firstAnswer { get; set; }
            public string SecondAnswer { get; set; }
            public string thirdAnswer { get; set; }
            public string fourAnswer { get; set; }
            public string firstQuestionAnswer { get; set; }
            public string secondQuestion { get; set; }
            public string fiveAnswer { get; set; }
            public string sixAnswer { get; set; }
            public string sevenAnswer { get; set; }
            public string eightAnswer { get; set; }
            public string secondQuestionAnswer { get; set; }
            public string thirdQuestion { get; set; }
            public string nineAnswer { get; set; }
            public string tenAnswer { get; set; }
            public string elevenAnswer { get; set; }
            public string twelveAnswer { get; set; }
            public string thirdhQuestionAnswer { get; set; }
            public string forthQuestion { get; set; }
            public string thirteenAnswer { get; set; }
            public string fourteenAnswer { get; set; }
            public string fifteenAnswer { get; set; }
            public string sixteenAnswer { get; set; }
            public string fourthQuestionAnswer { get; set; }
        }

        public class QuestionTable
        {
            public string firstQuestion { get; set; }
            public string firstQuestionAnswer { get; set; }
            public string secondQuestion { get; set; }
            public string secondQuestionAnswer { get; set; }
            public string thirdQuestion { get; set; }
            public string thirdhQuestionAnswer { get; set; }
            public string forthQuestion { get; set; }
            public string fourthQuestionAnswer { get; set; }
            public string QuestionHeaderId { get; set; }

        }
    }
}

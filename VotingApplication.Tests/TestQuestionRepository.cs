using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApplication.Entities;
using VotingApplication.Services;

namespace VotingApplication.Tests
{
    public class TestQuestionRepository : IQuestionRepository
    {

        public List<Question> GetAllQuestions()
        {
            var testQuestions = new List<Question>();
            testQuestions.Add(new Question { Id = 1, Title = "Question1", Status = true });
            testQuestions.Add(new Question { Id = 2, Title = "Question1", Status = true });

            return testQuestions;
        }

        public Question GetQuestionById(int id)
        {
            var testQuestions = new List<Question>();
            testQuestions.Add(new Question { Id = 1, Title = "Question1", Status = true });
            testQuestions.Add(new Question { Id = 2, Title = "Question1", Status = false });

            var q = testQuestions.FirstOrDefault(x => x.Id == id);
            return q;
        }

        public ResponseOption GetOptionById(int id, int questionId)
        {
            var testOptions = new List<ResponseOption>();
            testOptions.Add(new ResponseOption { Id = 1, option = "Option1" });
            testOptions.Add(new ResponseOption { Id = 2, option = "Option2" });

            var q = testOptions.FirstOrDefault(x => x.Id == id);
            return q;
        }

        public List<Question> GetQuestionsWithSpecificStatus(bool status)
        {
            var testQuestions = new List<Question>();
            testQuestions.Add(new Question { Id = 1, Title = "Question1", Status = true });
            testQuestions.Add(new Question { Id = 2, Title = "Question1", Status = false });
            return testQuestions.Where(q => q.Status == status).ToList();
        }

        public Question CreateQuestion(Question question)
        {
            var testQuestions = new List<Question>();
            testQuestions.Add(question);

            return testQuestions.SingleOrDefault(q => q.Title == question.Title);
        }

        public ResponseOption CreateResponseOption(ResponseOption option, int id)
        {
            var testResponseOption = new List<ResponseOption>();
            option.questionId = id;
            testResponseOption.Add(option);
            return testResponseOption.SingleOrDefault(r => r.option == option.option);
        }

        public Question updatedQuestion = null;
        public Question UpdateQuestion(Question question)
        {
            updatedQuestion = question;
            return updatedQuestion;
        }

        public ResponseOption updatedResponse = null; 
        public ResponseOption UpdateResponseOption(ResponseOption option)
        {
            updatedResponse = option;
            return updatedResponse;
        }

        public bool deleted = false;
        public void DeleteQuestion(int id)
        {
            deleted = true;
        }

        public bool deletedOption = false;
        public void DeleteResponseOption(int id, int questionId)
        {
            deleted = true;
        }

        public List<Result> GetAllQuestionResults()
        {
            var testResultList = new List<Result>();
            testResultList.Add(new Result { Id = 1, question = new Question() { Title = "test", Status = true }, responseOption = new ResponseOption() { option = "test" } });
            testResultList.Add(new Result { Id = 2, question = new Question() { Title = "test", Status = true }, responseOption = new ResponseOption() { option = "test" } });

            return testResultList;
        }

        public List<Result> GetSpecificResult(int questionId)
        {
            var testResultList = new List<Result>();
            testResultList.Add(new Result { Id = 1, question = new Question() { Id = 1,Title = "test", Status = true }, responseOption = new ResponseOption() { option = "test" } });
            testResultList.Add(new Result { Id = 2, question = new Question() { Id = 1,Title = "test", Status = true }, responseOption = new ResponseOption() { option = "test1" } });

            var results = testResultList.Where(r => r.question.Id == questionId).ToList();

            return results;
        }

        public Result SaveAnswer(Result result)
        {

            var testResult = new List<Result>();
            testResult.Add(result);
            return testResult.SingleOrDefault(r => r.Id == result.Id);
        }
    }
}

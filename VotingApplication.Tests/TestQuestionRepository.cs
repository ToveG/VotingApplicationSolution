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
            return new Question { Id = id, Title = "Question", Status = true };
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












        public List<Result> GetAllQuestionResults()
        {
            var testResultList = new List<Result>();
            testResultList.Add(new Result { Id = 1, question = new Question() { Title = "test", Status = true }, responseOption = new ResponseOption() { option = "test" } });
            testResultList.Add(new Result { Id = 2, question = new Question() { Title = "test", Status = true }, responseOption = new ResponseOption() { option = "test" } });

            return testResultList;
        }

        public List<Result> GetSpecificResult(int questionId)
        {
            throw new NotImplementedException();
        }







        


        public void DeleteQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteResponseOption(int id, int questionId)
        {
            throw new NotImplementedException();
        }


        

    public ResponseOption GetOptionById(int id, int questionId)
        {
            throw new NotImplementedException();
        }

        

        

        public Result SaveAnswer(Result result)
        {
            throw new NotImplementedException();
        }

        public Question UpdateQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public ResponseOption UpdateResponseOption(ResponseOption option)
        {
            throw new NotImplementedException();
        }
    }
}

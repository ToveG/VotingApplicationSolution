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
        public Question CreateQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public ResponseOption CreateResponseOption(ResponseOption option, int id)
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

        public List<Result> GetAllQuestionResults()
        {
            throw new NotImplementedException();
        }

        public List<Question> GetAllQuestions()
        {
            var testQuestions = new List<Question>();
            testQuestions.Add(new Question { Id = 1, Title = "Question1", Status = true});
            testQuestions.Add(new Question { Id = 2, Title = "Question1", Status = true});

            return testQuestions;
    }

    public ResponseOption GetOptionById(int id, int questionId)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestionById(int id)
        {
            return new Question { Id = id, Title = "Question", Status = true};
        }

        public List<Question> GetQuestionsWithSpecificStatus(bool status)
        {
            throw new NotImplementedException();
        }

        public List<Result> GetSpecificResult(int questionId)
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

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VotingApplication.Entities;


namespace VotingApplication.Services
{
    public class QuestionRepository : IQuestionRepository
    {
        private DataContext _ctx = new DataContext();
        
        public List<Question> GetAllQuestions()
        {
            return _ctx.Questions.Include(q => q.Answers).ToList();
        }

        public Question GetQuestionById(int id)
        {
            return _ctx.Questions.Include(q => q.Answers).SingleOrDefault(q => q.Id == id);
        }


        public List<Question> GetQuestionsWithSpecificStatus(bool status)
        {
            return _ctx.Questions.Where(q => q.Status == status).Include(q => q.Answers).ToList();
        }

        public Question CreateQuestion(Question _question)
        {
            var question = _ctx.Questions.Add(_question);
            _ctx.SaveChanges();
            return _ctx.Questions.SingleOrDefault(q => q.Id == question.Id);
        }

        public Question UpdateQuestion(Question _question)
        {
         
            _ctx.SaveChanges();
            return _ctx.Questions.SingleOrDefault(q => q.Id == _question.Id);
        }

        public void DeleteQuestion(int id)
        {
            var itemToDelete = GetQuestionById(id);
            _ctx.Questions.Remove(itemToDelete);
            _ctx.SaveChanges();
        }

        public ResponseOption GetOptionById(int id, int questionId)
        {
            var question = GetQuestionById(questionId);
            var responseOption = question.Answers.SingleOrDefault(a => a.Id == id);

            return responseOption;
        }


        public ResponseOption CreateResponseOption(ResponseOption option, int questionId)
        {
            option.questionId = questionId;
            var _option = _ctx.ResponseOptions.Add(option);
            _ctx.SaveChanges();
            return _ctx.ResponseOptions.SingleOrDefault(o => o.Id == _option.Id);
        }

        public ResponseOption UpdateResponseOption(ResponseOption option)
        {
            var _option = _ctx.ResponseOptions.SingleOrDefault(o => o.Id == option.Id);

            _option.option = option.option;

            _ctx.SaveChanges();
            return _ctx.ResponseOptions.SingleOrDefault(o => o.Id == _option.Id);
        }

        public void DeleteResponseOption(int id, int questionId)
        {
            var question = GetQuestionById(questionId);
            var itemToDelete = question.Answers.SingleOrDefault(a => a.Id == id);
            _ctx.ResponseOptions.Remove(itemToDelete);

            _ctx.SaveChanges();
        }





        public Result SaveAnswer(Result result)
        {
            _ctx.Results.Add(result);
            _ctx.SaveChanges();

            return _ctx.Results.SingleOrDefault(r => r.Id == result.Id);
        }

        //public List<Result> GetAllQuestionResults()
        //{

        //}

        //public List<Result> GetSpecificResult(int questionId)
        //{
        //    //    List<Result> results = _ctx.Results.Where(r => r.question.Id == questionId && r.responseOption.Id == responseId).ToList();
        //    var results = _ctx.Results.Where(r => r.question.Id == questionId).ToList(); 
        //    return results;
        //}



    }


}

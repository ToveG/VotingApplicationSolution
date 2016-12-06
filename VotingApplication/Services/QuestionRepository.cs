using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VotingApplication.Entities;


namespace VotingApplication.Services
{
    public class QuestionRepository : IQuestionRepository
    {
        private DataContext _ctx = null;

        public QuestionRepository( DataContext ctx)
        {
            _ctx = ctx;
        }
        
        public List<Question> GetAllQuestions()
        {
            return _ctx.Questions.ToList();


          // return _ctx.Questions.Include(q => q.Answers).ToList<>;
         //   return _ctx.TodoLists.Include(l => l.TodoListItems).ToList();
        }

        public Question GetQuestionById(int id)
        {
            return _ctx.Questions.SingleOrDefault(q => q.Id == id);
          //  return _ctx.Questions.Include(q => q.ResponseOptions).SingleOrDefault(q => q.Id == id);
        }


        public List<Question> GetQuestionsWithSpecificStatus(bool status)
        {
            return _ctx.Questions.Where(q => q.Status == status).ToList();
        }

        public Question CreateQuestion(Question _question)
        {
            var question = _ctx.Questions.Add(_question);
            _ctx.SaveChanges();
            return _ctx.Questions.SingleOrDefault(q => q.Id == question.Id);
        }

        public Question UpdateQuestion(Question _question)
        {
            var question = _ctx.Questions.SingleOrDefault(q => q.Id == _question.Id);

            question.Title = _question.Title;
            question.Status = _question.Status;

            _ctx.SaveChanges();
            return _ctx.Questions.SingleOrDefault(q => q.Id == question.Id);
        }

        public void DeleteQuestion(int id)
        {
            var itemToDelete = GetQuestionById(id);
            _ctx.Questions.Remove(itemToDelete);
            _ctx.SaveChanges();
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

        public void DeleteResponseOption(int id)
        {
            var itemToDelete = _ctx.ResponseOptions.SingleOrDefault(o => o.Id == id);
            _ctx.ResponseOptions.Remove(itemToDelete);
        }
















        
    }


}

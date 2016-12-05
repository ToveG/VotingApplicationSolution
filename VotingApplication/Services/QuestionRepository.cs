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

        public List<Question> GetQuestions()
        {
            return _ctx.Questions.Include(q => q.ResponseOptions).ToList<>;
         //   return _ctx.TodoLists.Include(l => l.TodoListItems).ToList();
        }

        public Question GetQuestionById(int id)
        {
            return _ctx.Questions.Include(q => q.ResponseOptions).SingleOrDefault(q => q.Id == id);
        }

        public List<ResponseOption> GetResonseOptions(int questionId)
        {
            return _ctx.ResponseOptions.Where(q => q.questionId == questionId).ToList();
           // return _ctx.TodoListItems.Where(l => l.TodoListId == todoListId).ToList();
        }

        public ResponseOption GetResponseOptions(int id, int questionId)
        {
            var question = GetQuestionById(questionId);
            var responseItem = question.Answers.SingleOrDefault(i => i.Id == id);

            return responseItem;
        }

        public ResponseOption CreateResponseOption(ResponseOption responseOption, int questionId)
        {
            responseOption.questionId = questionId;
            var responseItem = _ctx.ResponseOptions.Add(responseOption);
            _ctx.SaveChanges();
            return _ctx.ResponseOptions.SingleOrDefault(r => r.Id == responseItem.Id);
        }

        public ResponseOption UpdateToListItem(ResponseOption responseOption)
        {
            var resorseItem = _ctx.ResponseOptions.Update(resorseItem);
            _ctx.SaveChanges();
            return _ctx.ResponseOptions.SingleOrDefault(r => r.Id == resorseItem.Entity.Id);
        }

        public void DeleteResponseOption(int id, int questionId)
        {
            var question = GetQuestionById(questionId);
            var itemToDelete = question.Answers.SingleOrDefault(a => a.Id == id);
            _ctx.ResponseOptions.Remove(itemToDelete);
            _ctx.SaveChanges();
        }
    }


}
}
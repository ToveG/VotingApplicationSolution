using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VotingApplication.Entities;

namespace VotingApplication.Services
{
    public class ResponseOptionRepository : IResponseOptionRepository
    {
        private DataContext _ctx = null;

        public ResponseOptionRepository(DataContext ctx)
        {
            _ctx = ctx;
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
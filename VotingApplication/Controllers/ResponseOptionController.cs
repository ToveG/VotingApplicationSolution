using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VotingApplication.Entities;
using VotingApplication.Models;
using VotingApplication.Services;

namespace VotingApplication.Controllers
{
    public class ResponseOptionController : ApiController
    {
        private IQuestionRepository _questionRepository = null;
        private DataContext ctx = new DataContext();

        public IQuestionRepository QuestionRepository
        {
            get
            {
                if (_questionRepository == null)
                    _questionRepository = new QuestionRepository();

                return _questionRepository;
            }
            set { _questionRepository = value; }
        }
        
        //Funkar
        [Route("api/questions/{questionId}/responseOptions")]
        [HttpPost]
        public IHttpActionResult CreateResponseOption(int questionId,
           [FromBody] CreateResponseOption responseOption)
        {
            if (responseOption == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var question = QuestionRepository.GetQuestionById(questionId);

            if (question == null)
            {
                return NotFound();
            }

            var itemToInsert = new Models.ResponseOption()
            {
                option = responseOption.option
            };

            var item = QuestionRepository.CreateResponseOption(Mapper.Map<Entities.ResponseOption>(itemToInsert), questionId);

            return Created("GetResponseOption", Mapper.Map<Models.ResponseOption>(item));
        }

        //Fungerar
        [Route("api/questions/{questionId}/responseOptions/{id}")]
        [HttpPut()]
        public IHttpActionResult UpdateResponseOption(int questionId, int id,
          [FromBody] CreateResponseOption responseOption)
        {
            if (responseOption == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var question = QuestionRepository.GetQuestionById(questionId);
            if (question == null)
            {
                return NotFound();
            }

            var responseToUpdate = QuestionRepository.GetOptionById(id, questionId);
            
            if (responseToUpdate == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            responseToUpdate.option = responseOption.option;

            QuestionRepository.UpdateResponseOption(responseToUpdate);

            return StatusCode(HttpStatusCode.NoContent);
        }


        [Route("api/questions/{questionId}/responseOptions/{id}")]
        [HttpDelete()]
        public IHttpActionResult DeleteResponseOption(int questionId, int id)
        {
            var question = QuestionRepository.GetQuestionById(questionId);

            if (question == null)
            {
                return NotFound();
            }

            QuestionRepository.DeleteResponseOption(id, questionId);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

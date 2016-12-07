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
   [Route("api/questions")]
    public class QuestionController : ApiController
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


        [HttpGet]
        public IHttpActionResult Get()
        {
            var questionEntities = QuestionRepository.GetAllQuestions();


            return Ok(Mapper.Map<IEnumerable<Models.Question>>(questionEntities));
        }

        [Route("api/questions/{id}")]
        [HttpGet]
        public IHttpActionResult GetSpecificQuestion(int id)
        {
            var questionEntity = QuestionRepository.GetQuestionById(id);
            if (questionEntity == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Models.Question>(questionEntity));
        }

        [Route("api/questions/status/{status}")]
        [HttpGet]
        public IHttpActionResult GetQuestionByStatus(bool status)
        {
            var questionEntities = QuestionRepository.GetQuestionsWithSpecificStatus(status);
            if (questionEntities == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<IEnumerable<Models.Question>>(questionEntities));
        }

        [Route("api/questions")]
        [HttpPost]
        public IHttpActionResult CreateQuestion(
        [FromBody] CreateQuestion questionItem)
        {
            if (questionItem == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToInsert = new Models.Question()
            {
                Title = questionItem.Title,
                Status = questionItem.Status
            };

            var item = QuestionRepository.CreateQuestion(Mapper.Map<Entities.Question>(itemToInsert));

            //ingen aning om detta är rätt
            return Created("GetTodoListItem", Mapper.Map<Models.Question>(item));
        }

        [Route("api/questions/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateQuestion(int id,
          [FromBody] CreateQuestion question)
        {
            if (question == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questionToUpdate = QuestionRepository.GetQuestionById(id);

            if (questionToUpdate == null)
            {
                return NotFound();
            }

            questionToUpdate.Title = question.Title;
            questionToUpdate.Status = question.Status;

            _questionRepository.UpdateQuestion(questionToUpdate);
            
            return StatusCode(HttpStatusCode.NoContent);
        }

       
        [Route("api/questions/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteQuestion(int id)
        {
            var question = QuestionRepository.GetQuestionById(id);

            if (question == null)
            {
                return NotFound();
            }

            QuestionRepository.DeleteQuestion(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

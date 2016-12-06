using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VotingApplication.Models;
using VotingApplication.Services;

namespace VotingApplication.Controllers
{
   [Route("api/questions")]
    public class QuestionController : ApiController
    {
        //[Route("customers/{customerId}/orders")]

        private IQuestionRepository _questionRepository;

        public QuestionController( IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var questionEntities = _questionRepository.GetAllQuestions();

            return Ok(Mapper.Map<IEnumerable<Models.Question>>(questionEntities));
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetSpecificQuestion(int id)
        {
            var questionEntity = _questionRepository.GetQuestionById(id);
            if (questionEntity == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Models.Question>(questionEntity));
        }

        [Route("{status}")]
        [HttpGet]
        public IHttpActionResult GetQuestionByStatus(bool status)
        {
            var questionEntities = _questionRepository.GetQuestionsWithSpecificStatus(status);
            if (questionEntities == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Models.Question>(questionEntities));
        }

        // [Route("{todoListId}/todolistitems")]
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

            var itemToInsert = new Question()
            {
                Title = questionItem.Title,
                Status = questionItem.Status
            };

            var item = _questionRepository.CreateQuestion(Mapper.Map<Entities.Question>(itemToInsert));

            //ingen aning om detta är rätt
            return Created("GetTodoListItem", Mapper.Map<Models.Question>(item));
        }

        // [HttpPut("{todoListId}/todolistitems/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateQuestion(
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

            _questionRepository.UpdateQuestion(Mapper.Map<Entities.Question>(question));

            return StatusCode(HttpStatusCode.NoContent);
        }


        //[HttpDelete("{todoListId}/todolistitems/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteQuestion(int id)
        {
            var question = _questionRepository.GetQuestionById(id);

            if (question == null)
            {
                return NotFound();
            }

            _questionRepository.DeleteQuestion(id);
            return StatusCode(HttpStatusCode.NoContent);
        }


    }
}

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


        //[Route("{questionId}/responseOption")]
        //[HttpGet()]
        //public IHttpActionResult GetResponseOptions(int questionId)
        //{
        //    try
        //    {
        //        var questionEntities = _questionRepository.GetResponseOptions(questionId);

        //        if (questionEntities == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(Mapper.Map<IEnumerable<Models.Question>>(questionEntities));
        //    }
        //    catch (Exception ex)
        //    {
        //          return StatusCode(HttpStatusCode.BadRequest);
        //    }
        //}
        //[Route("{questionId}/responseOption/{id}", Name = "GetResponseOptions")]
        //[HttpGet]
        //public IHttpActionResult GetResponseOptions(int questionId, int id)
        //{
        //    try
        //    {
        //        var question = _questionRepository.GetQuestionById(questionId);

        //        if (question == null)
        //        {
        //            return NotFound();
        //        }
        //        var response = _questionRepository.GetResponseOption(id, questionId);
        //        if (response == null)
        //            return NotFound();

        //        return Ok(Mapper.Map<Models.ResponseOption>(response));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "A problem occured.");
        //    }
        //}

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

        [Route("{questionId}/responseOption/{id}")]
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
            var question = _questionRepository.GetQuestionById(questionId);
            if (question == null)
            {
                return NotFound();
            }

            _questionRepository.UpdateResponseOption(Mapper.Map<Entities.ResponseOption>(responseOption));

            //if (responseOptionToUpdate == null)
            //    return NotFound();

            //responseOptionToUpdate.option = responseOption.option;

            //_questionRepository.UpdateToListItem(responseOptionToUpdate);
            //return NoContent();
            return StatusCode(HttpStatusCode.NoContent);
        }

        //[Route("{questionId}/responseOption/{id}")]
        //[HttpPatch()]
        //public IHttpActionResult PartiallyUpdateresponseOption(int questionId, int id,
        //  [FromBody] JsonPatchDocument<CreateResponseOption> patchDoc)
        //{
        //    if (patchDoc == null)
        //    {
        //        return BadRequest();
        //    }

        //    var question = _questionRepository.GetQuestionById(questionId);
        //    if (question == null)
        //    {
        //        return NotFound();
        //    }

        //    var responseOption = _questionRepository.GetResponseOption(id, questionId);
        //    if (responseOption == null)
        //    {
        //        return NotFound();
        //    }

        //    var responseOptionToPatch =
        //           new CreateResponseOption()
        //           {
        //               option = responseOption.option
        //           };

        //    patchDoc.ApplyTo(responseOptionToPatch, ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    //if (responseOptionToPatch.Description == todoListItemToPatch.Title)
        //    //{
        //    //    ModelState.AddModelError("Description", "The provided description should be different from the name.");
        //    //}

        //    TryValidateModel(responseOptionToPatch);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    responseOption.option = responseOptionToPatch.option;

        //    _questionRepository.UpdateToListItem(responseOption);
        //    return NoContent();
        //}

        [Route("{questionId}/responseoptions/{id}")]
        [HttpDelete()]
        public IHttpActionResult DeleteResponseOption(int questionId, int id)
        {
            var question = _questionRepository.GetQuestionById(questionId);

            if (question == null)
            {
                return NotFound();
            }

            _questionRepository.DeleteResponseOption(id, questionId);
            return StatusCode(HttpStatusCode.NoContent);
        }


    }
}

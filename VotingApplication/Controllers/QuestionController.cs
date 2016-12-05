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
        QuestionRepository _questionRepository = new QuestionRepository();

        [HttpGet]
        public IHttpActionResult Get()
        {
            var questionEntities = _questionRepository.GetQuestions();

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

       // [Route("{todoListId}/todolistitems")]
        [HttpPost]
        public IHttpActionResult CreateQuestion(
    [FromBody] CreateQuestion questionItem)
        {
            if (questionItem == null)
            {
                return BadRequest();
            }

            //if (questionItem.Description == todoListItem.Title)
            //{
            //    ModelState.AddModelError("Description", "The provided description should be different from the title.");
            //}

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //  var todoList = _todoListRepository.GetTodoListById(todoListId);

            //var question = _questionRepository.CreateQuestion(Mapper.Map<Entities.Question>());

            //if (todoList == null)
            //{
            //    return NotFound();
            //}

            var itemToInsert = new Question()
            {
                title = questionItem.Title,
                Status = questionItem.Status
            };

            var item = _questionRepository.CreateQuestion(Mapper.Map<Entities.Question>(itemToInsert));

            return CreatedAtRoute("GetTodoListItem", Mapper.Map<Models.Question>(item));
        }



        [HttpPut("{todoListId}/todolistitems/{id}")]
        public IActionResult UpdateQuestion(int todoListId, int id,
          [FromBody] CreateTodoListItem todoListItem)
        {
            if (todoListItem == null)
            {
                return BadRequest();
            }

            if (todoListItem.Description == todoListItem.Title)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the title.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var todoList = _todoListRepository.GetTodoListById(todoListId);
            if (todoList == null)
            {
                return NotFound();
            }

            var todoListItemToUpdate = _todoListRepository.GetTodoListItem(id, todoListId);

            if (todoListItemToUpdate == null)
                return NotFound();

            todoListItemToUpdate.Title = todoListItem.Title;
            todoListItemToUpdate.Description = todoListItem.Description;
            todoListItemToUpdate.DueDate = todoListItem.DueDate;

            _todoListRepository.UpdateToListItem(todoListItemToUpdate);
            return NoContent();
        }

        [HttpPatch("{todolistid}/todolistitems/{id}")]
        public IActionResult PartiallyUpdateTodoListItem(int todolistId, int id,
          [FromBody] JsonPatchDocument<CreateTodoListItem> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var todoList = _todoListRepository.GetTodoListById(todolistId);
            if (todoList == null)
            {
                return NotFound();
            }

            var todoListItem = _todoListRepository.GetTodoListItem(id, todolistId);
            if (todoListItem == null)
            {
                return NotFound();
            }

            var todoListItemToPatch =
                   new CreateTodoListItem()
                   {
                       Title = todoListItem.Title,
                       Description = todoListItem.Description
                   };

            patchDoc.ApplyTo(todoListItemToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (todoListItemToPatch.Description == todoListItemToPatch.Title)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name.");
            }

            TryValidateModel(todoListItemToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            todoListItem.Title = todoListItemToPatch.Title;
            todoListItem.Description = todoListItemToPatch.Description;

            _todoListRepository.UpdateToListItem(todoListItem);
            return NoContent();
        }

        [HttpDelete("{todoListId}/todolistitems/{id}")]
        public IActionResult DeleteTodoListItem(int todoListId, int id)
        {
            var todoList = _todoListRepository.GetTodoListById(todoListId);

            if (todoList == null)
            {
                return NotFound();
            }

            _todoListRepository.DeleteTodoListItem(id, todoListId);
            return NoContent();
        }


    }
}

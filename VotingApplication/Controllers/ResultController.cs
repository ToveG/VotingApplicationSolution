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
    public class ResultController : ApiController
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

        //[Route("api/result")]
        //[HttpGet]
        //public IHttpActionResult Get()
        //{
        //    var questionResults = QuestionRepository.GetAllQuestionResults();
        //    return Ok(Mapper.Map<IEnumerable<Models.Result>>(questionResults));
        //}

        // [Route("api/questions/{id}/resultone/{optionId}/resulttwo/{secondOptionId}")]
        //[Route("api/results/{id}")]
        //[HttpGet]
        //public IHttpActionResult GetSpecificResult(int id)
        //{
        //    var allAnswers = QuestionRepository.GetSpecificResult(id);

        //    var grouped = allAnswers.GroupBy(a => a.responseOption.option.ToLower()).ToArray();
        //    //    var totalAnswers= allAnswers.Count();
        //    //    var optionOne = allAnswers.Where(a => a.responseOption.Id == optionId).ToList().Count();
        //    //    var optionTwo = allAnswers.Where(a => a.responseOption.Id == secondOptionId).ToList().Count();

        //    //    var procentOptionOne = optionOne / totalAnswers * 100;
        //    //    var procentOptionTwo = optionTwo / totalAnswers * 100;

        //    //    //Models.ViewResult viewResult = new Models.ViewResult();
        //    //    //viewResult.question == 

        //        return Ok();
        //    }

        ////[Route("api/{questionId}/result/{responseOptionId}")]
        ////[HttpPost]
        ////public IHttpActionResult SaveSelectedAnswer(int questionId, 
        ////    int optionId)
        ////    //[FromBody] Models.Result result )
        ////{
           

        ////    var item = QuestionRepository.SaveAnswer(Mapper.Map<Entities.Result>(itemToInsert));

        ////    return Created("AnswerSaved", Mapper.Map<Models.Result>(item));
        ////}














        //var question = QuestionRepository.GetQuestionById(questionId);

        //    if (question == null)
        //    {
        //        return NotFound();
        //    }
            
        //    QuestionRepository.SaveAnswer(questionId, optionId);
        //    return StatusCode(HttpStatusCode.NoContent);
        //}
        

        }


    }


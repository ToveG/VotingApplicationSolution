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

//lägg till try så att den inte pangar om jag förösker kolla resultat på en fråga som ingen svarat på än.
//den borde kanske säga NoContent istället. 
//borde kanske också flytta över hela groupby grejen till repositoryt...? 

            [Route("api/result/question/{id}")]
            [HttpGet]
            public IHttpActionResult GetResultForSpecificQuestion(int id)
        {
            var question = QuestionRepository.GetQuestionById(id);
            if(question == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            var allAnswers = QuestionRepository.GetSpecificResult(id);
            
            var resultsCount = allAnswers.GroupBy(a => a.responseOption).
                Select(group =>
                new
                {
                  Name = group.Key,
             //     Notice = group.ToList(),
                    Count = group.Count()
                }).ToArray();

            double totalAnswers = allAnswers.Count;
            double resultOne = resultsCount[0].Count;
            double resultTwo = resultsCount[1].Count;

            var name = resultsCount[0].Name;

            var procent = 100;
            double optionOneInProcent = Math.Round((resultOne / totalAnswers) * procent);
            double optionTwoInProcent = Math.Round((resultTwo / totalAnswers) * procent);

            ViewResult viewResult = new ViewResult();
            viewResult.question = question.Title; 
            viewResult.option1 = resultsCount[0].Name.option.ToString();
            viewResult.option2 = resultsCount[1].Name.option.ToString();
            viewResult.procentOption1 = optionOneInProcent + " %";
            viewResult.procentOption2 = optionTwoInProcent + " %";
            viewResult.countOption1 = resultOne;
            viewResult.countOption2 = resultTwo;

            return Ok(viewResult);


        }
        

        [Route("api/question/{questionId}/result/{optionId}")]
        [HttpPost]
        public IHttpActionResult SaveSelectedAnswer(int questionId,
            int optionId)
        {
            var question = QuestionRepository.GetQuestionById(questionId);
            if(question == null)
            {
                return NotFound();
            }

            var option = QuestionRepository.GetOptionById(optionId, questionId);

            Entities.Result result = new Entities.Result();
            result.question = question;
            result.responseOption = option;

            QuestionRepository.SaveAnswer(result);            

            return Created("AnswerSaved", Mapper.Map<Models.Result>(result));
        }














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


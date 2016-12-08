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
        
            [Route("api/result")]
            [HttpGet]
            public IHttpActionResult Get()
        {
            var questions = QuestionRepository.GetAllQuestions();
            if (questions == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            List<ViewResultModel> list = new List<ViewResultModel>();
            foreach(var q in questions)
            {
                try
                {
                    var result = GetResultForSpecificQuestion(q);
                    if (result.option1 != null)
                        list.Add(result);
                }
                catch (Exception)
                {
                    return StatusCode(HttpStatusCode.NotFound);
                }
                
            }
            return Ok(list);
        }

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

            if(allAnswers == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            var resultsCount = allAnswers.GroupBy(a => a.responseOption).
                Select(group =>
                new
                {
                    Name = group.Key,
                    Count = group.Count()
                    
                }).ToArray();

            double totalAnswers = allAnswers.Count;
            double resultOne = resultsCount[0].Count;
            double resultTwo = resultsCount[1].Count;

            var name = resultsCount[0].Name;

            var optionOneInProcent = getResultInProcent(totalAnswers, resultOne);
            var optionTwoInProcent = getResultInProcent(totalAnswers, resultTwo);

            ViewResultModel viewResult = new ViewResultModel();

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
            else if(question.Status == false)
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            var option = QuestionRepository.GetOptionById(optionId, questionId);

            Entities.Result result = new Entities.Result();
            result.question = question;
            result.responseOption = option;

            QuestionRepository.SaveAnswer(result);            

            return Created("AnswerSaved", Mapper.Map<Models.Result>(result));
        }

        private double getResultInProcent(double totalAmount, double partOfTotal)
        {
            var result = Math.Round((partOfTotal / totalAmount) * 100);
            return result;
        }


        public ViewResultModel GetResultForSpecificQuestion(Entities.Question q)
        {
         
            var allAnswers = QuestionRepository.GetSpecificResult(q.Id);

            if (allAnswers == null)
            {
                throw new Exception();
            }
            var resultsCount = allAnswers.GroupBy(a => a.responseOption).
                Select(group =>
                new
                {
                    Name = group.Key,
                    Count = group.Count()

                }).ToArray();

            if (resultsCount.Length == 0)
            {
                ViewResultModel emptyViewResult = new ViewResultModel();

                emptyViewResult.question = q.Title;
                return emptyViewResult;
            }

            double totalAnswers = allAnswers.Count;
            double resultOne = resultsCount[0].Count;
            double resultTwo = resultsCount[1].Count;

            var name = resultsCount[0].Name;

            var optionOneInProcent = getResultInProcent(totalAnswers, resultOne);
            var optionTwoInProcent = getResultInProcent(totalAnswers, resultTwo);

            ViewResultModel viewResult = new ViewResultModel();

            viewResult.question = q.Title;
            viewResult.option1 = resultsCount[0].Name.option.ToString();
            viewResult.option2 = resultsCount[1].Name.option.ToString();
            viewResult.procentOption1 = optionOneInProcent + " %";
            viewResult.procentOption2 = optionTwoInProcent + " %";
            viewResult.countOption1 = resultOne;
            viewResult.countOption2 = resultTwo;

            return viewResult;
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


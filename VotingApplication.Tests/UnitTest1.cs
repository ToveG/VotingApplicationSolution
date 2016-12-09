using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingApplication.Controllers;
using System.Collections.Generic;
using VotingApplication.Models;
using System.Web.Http.Results;

namespace VotingApplication.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllQuestions_ShouldReturn2Questions()
        {
            var x = questionController.Get() as OkNegotiatedContentResult<IEnumerable<Question>>;

            Assert.AreEqual(2, new List<Question>(x.Content).Count);
        }

        [TestMethod]
        public void GetSpecificQuestion_ShouldReturn1question()
        {
            var x = questionController.GetSpecificQuestion(1) as OkNegotiatedContentResult<Question>;

            Assert.AreEqual(1, x.Content.Id);
        }

        [TestMethod]
        public void GetQuestionByStatus_ShouldReturnOneQuestion()
        {
            var x = questionController.GetQuestionByStatus(true) as OkNegotiatedContentResult<IEnumerable<Question>>;

            Assert.AreEqual(1, new List<Question>(x.Content).Count);
        }

        [TestMethod]
        public void CreateQuestion_ShouldCreateAQuestion()
        {
            CreateQuestion q = new CreateQuestion { Title = "test", Status = true };
            
            var x = questionController.CreateQuestion(q) as CreatedNegotiatedContentResult<Question>;

            Assert.AreEqual(q.Title, x.Content.Title);
        }

        [TestMethod]
        public void CreateResponseOption_ShouldCreateAResponseOption()
        {
            CreateResponseOption r = new CreateResponseOption { option = "test"};

            var x = responseOptionController.CreateResponseOption(1,r) as CreatedNegotiatedContentResult<ResponseOption>;

            Assert.AreEqual(r.option, x.Content.option);
        }

        [TestMethod]
        public void UpdateQuestion_ShouldCreateAResponseOption()
        {
            CreateQuestion q = new CreateQuestion { Title = "test_update", Status = true };

            //retunera en statusCode
            var x = questionController.UpdateQuestion(1,q) as CreatedNegotiatedContentResult<ResponseOption>;

            Assert.AreEqual(r.option, x.Content.option);
        }

        //[TestMethod]
        //public void UpdateResponseOption_ShouldCreateAResponseOption()
        //{
        //    CreateResponseOption r = new CreateResponseOption { option = "test" };

        //    var x = responseOptionController.CreateResponseOption(1, r) as CreatedNegotiatedContentResult<ResponseOption>;

        //    Assert.AreEqual(r.option, x.Content.option);
        //}





        [TestMethod]
        public void GetAllResults_ShouldReturn2Results()
        {
            var x = resultController.Get() as OkNegotiatedContentResult<IEnumerable<Result>>;

            Assert.AreEqual(2, new List<Result>(x.Content).Count);
        }





        [TestMethod]
        public void DeleteQuestion_ShouldReturnNull()
        {
            //OkNegotiatedContentResult<Question> noQuestionExpected = null;
            //CreateQuestion q = new CreateQuestion { Title = "test", Status = true };
            //var _q = questionController.CreateQuestion(q) as OkNegotiatedContentResult<Question>;
            //var getQuestion = questionController.GetSpecificQuestion(_q.Content.Id) as OkNegotiatedContentResult<Question>;
            //if(getQuestion != null)
            //{
            //    questionController.DeleteQuestion(getQuestion.Content.Id);
            //    noQuestionExpected = questionController.GetSpecificQuestion(getQuestion.Content.Id) as OkNegotiatedContentResult<Question>;
            //}

            //Assert.IsNull(noQuestionExpected);
        }



        





        [TestInitialize]
        public void BeforeEachTest()
        {
            WebApiApplication.InitializeAutoMapper();
            questionController = new QuestionController();
            resultController = new ResultController();
            responseOptionController = new ResponseOptionController();
            responseOptionController.QuestionRepository = new TestQuestionRepository();
            resultController.QuestionRepository = new TestQuestionRepository();
            questionController.QuestionRepository = new TestQuestionRepository();
        }

        QuestionController questionController;
        ResponseOptionController responseOptionController;
        ResultController resultController;
    }
}

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

            questionController.UpdateQuestion(1, q);

            Assert.AreEqual(q.Title, repository.updatedQuestion.Title);
        }

        [TestMethod]
        public void DeleteQuestion_ShouldBeTrue()
        {
            questionController.DeleteQuestion(1);

            Assert.IsTrue(repository.deleted);
        }

        [TestMethod]
        public void DeleteResponseOption_ShouldBeTrue()
        {
            responseOptionController.DeleteResponseOption(1,1);

            Assert.IsTrue(repository.deleted);
        }

        [TestMethod]
        public void UpdateResponseOption_ShouldCreateAResponseOption()
        {
            
            CreateResponseOption r = new CreateResponseOption { option = "test" };
            responseOptionController.UpdateResponseOption(1, 1, r);

            Assert.AreEqual(r.option, repository.updatedResponse.option);
        }

        [TestMethod]
        public void GetAllResults_ShouldReturn2Results()
        {
            var x = resultController.Get() as OkNegotiatedContentResult<List<ViewResultModel>>;

            Assert.AreEqual(1, new List<ViewResultModel>(x.Content).Count);
        }

        [TestMethod]
        public void GetResultsForSpecificQuestion_ShouldNotBeNull()
        {
            var x = resultController.GetResultForSpecificQuestion(1) as OkNegotiatedContentResult<ViewResultModel>;

            Assert.IsNotNull(x.Content.countOption1);
        }

        [TestMethod]
        public void SaveResults_ShouldReturn1ResultsWithId1()
        {
            Result r = new Result { question =  new Question { Id = 1} };

            var x = resultController.SaveSelectedAnswer(1, 1) as CreatedNegotiatedContentResult<Result>;

            Assert.AreEqual(r.question.Id, x.Content.question.Id);
        }

        [TestInitialize]
        public void BeforeEachTest()
        {
            WebApiApplication.InitializeAutoMapper();
            questionController = new QuestionController();
            resultController = new ResultController();
            responseOptionController = new ResponseOptionController();

            repository = new TestQuestionRepository();
            responseOptionController.QuestionRepository = repository;
            resultController.QuestionRepository = repository;
            questionController.QuestionRepository = repository;
        }

        TestQuestionRepository repository;
        QuestionController questionController;
        ResponseOptionController responseOptionController;
        ResultController resultController;
    }
}

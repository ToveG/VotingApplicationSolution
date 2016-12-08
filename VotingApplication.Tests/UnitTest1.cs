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
        public void GetAllQuestions_ShouldReturnAllQuestions()
        {
            var x = controller.Get() as OkNegotiatedContentResult<IEnumerable<Models.Question>>;

            Assert.AreEqual(2, new List<Models.Question>(x.Content).Count);
        }

        [TestMethod]
        public void GetSpecificQuestion_Should()
        {
            var x = controller.GetSpecificQuestion(1) as OkNegotiatedContentResult<Models.Question>;

            Assert.AreEqual(1, x.Content.Id);
        }

        [TestInitialize]
        public void BeforeEachTest()
        {
            WebApiApplication.InitializeAutoMapper();
            controller = new QuestionController();
            controller.QuestionRepository = new TestQuestionRepository();
        }

        QuestionController controller;
    }
}

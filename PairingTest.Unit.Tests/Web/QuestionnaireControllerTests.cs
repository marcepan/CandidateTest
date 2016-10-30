using Moq;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Interfaces;
using PairingTest.Web.Models;

namespace PairingTest.Unit.Tests.Web {
   [TestFixture]
   public class QuestionnaireControllerTests {
      private Mock<IQuestionnaireService> _questionnaireServiceMock;

      [SetUp]
      public void Setup() {
         _questionnaireServiceMock = new Mock<IQuestionnaireService>();
      }

      [Test]
      public void ShouldGetIndexView() {
         //Arrange
         _questionnaireServiceMock.Setup(x => x.GetQuestions()).ReturnsAsync(new QuestionnaireViewModel());
         var questionnaireController = new QuestionnaireController(_questionnaireServiceMock.Object);

         //Act
         var result = questionnaireController.Index().Result;

         //Assert
         Assert.That(result.ViewName, Is.EqualTo("Index"));
      }

      [Test]
      public void ShouldGetResponseView() {
         //Arrange
         _questionnaireServiceMock.Setup(x => x.GetQuestions()).ReturnsAsync(new QuestionnaireViewModel());
         var questionnaireController = new QuestionnaireController(_questionnaireServiceMock.Object);

         //Act
         var result = questionnaireController.Response(new QuestionnaireViewModel());

         //Assert
         Assert.That(result.ViewName, Is.EqualTo("Response"));
      }
   }
}
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PairingTest.Web.Interfaces;
using PairingTest.Web.Models;
using PairingTest.Web.Services;

namespace PairingTest.Unit.Tests.Web {
   [TestFixture]
   public class QuestionnaireServiceTests {
      private Mock<IHttpDataProvider> _httpDataProviderMock;
      private string _expectedTitle;
      private IList<string> _expectedQuestions;
      [SetUp]
      public void Setup() {
         _httpDataProviderMock = new Mock<IHttpDataProvider>();
         _expectedTitle = "My expected quesitons";
         _expectedQuestions = new List<string>
         {
            "What is the capital of Cuba?",
            "What is the capital of France?",
            "What is the capital of Poland?",
            "What is the capital of Germany?"
         };
         _httpDataProviderMock.Setup(x => x.Get<QuestionnaireViewModel>(It.IsAny<string>())).ReturnsAsync(new QuestionnaireViewModel {
            QuestionsText = _expectedQuestions
         });
      }

      [Test]
      public void ShouldGetQuestions() {
         //Arrange
         _httpDataProviderMock.Setup(x => x.Get<QuestionnaireViewModel>(It.IsAny<string>())).ReturnsAsync(new QuestionnaireViewModel {
            QuestionsText = _expectedQuestions
         });
         var service = new QuestionnaireService(_httpDataProviderMock.Object);

         //Act
         var result = service.GetQuestions().Result;

         //Assert
         CollectionAssert.AreEqual(_expectedQuestions, result.QuestionsText);
      }

      [Test]
      public void ShouldHasTitle() {
         //Arrange
         _httpDataProviderMock.Setup(x => x.Get<QuestionnaireViewModel>(It.IsAny<string>())).ReturnsAsync(new QuestionnaireViewModel {
            QuestionnaireTitle = _expectedTitle
         });
         var service = new QuestionnaireService(_httpDataProviderMock.Object);

         //Act
         var result = service.GetQuestions().Result;

         //Assert
         Assert.That(result.QuestionnaireTitle, Is.EqualTo(_expectedTitle));
      }
   }
}

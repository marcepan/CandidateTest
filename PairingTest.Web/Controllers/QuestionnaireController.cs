using System.Threading.Tasks;
using System.Web.Mvc;
using PairingTest.Web.Interfaces;
using PairingTest.Web.Models;

namespace PairingTest.Web.Controllers {
   public class QuestionnaireController : Controller
   {
      private readonly IQuestionnaireService _questionnaireService;

      public QuestionnaireController(IQuestionnaireService questionnaireService) {
         _questionnaireService = questionnaireService;
      }
      public async Task<ViewResult> Index() {
         var questionnaire = await _questionnaireService.GetQuestions();

         return View("Index", questionnaire);
      }

      [HttpPost]
      public ViewResult Response(QuestionnaireViewModel model) {
         return View("Response");
      }
   }
}

using System.Configuration;
using System.Threading.Tasks;
using PairingTest.Web.Interfaces;
using PairingTest.Web.Models;

namespace PairingTest.Web.Services {
   public class QuestionnaireService : IQuestionnaireService {
      private static string QuestionnaireApiUrl => ConfigurationManager.AppSettings.Get("QuestionnaireServiceUri");
      private readonly IHttpDataProvider _httpService;

      public QuestionnaireService(IHttpDataProvider httpDataProvder) {
         _httpService = httpDataProvder;
      }

      public async Task<QuestionnaireViewModel> GetQuestions() {
         var response = await _httpService.Get<QuestionnaireViewModel>(QuestionnaireApiUrl);
         return response;
      }
   }
}
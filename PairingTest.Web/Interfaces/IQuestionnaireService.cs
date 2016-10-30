using System.Threading.Tasks;
using PairingTest.Web.Models;

namespace PairingTest.Web.Interfaces {
   public interface IQuestionnaireService {
      Task<QuestionnaireViewModel> GetQuestions();
   }
}

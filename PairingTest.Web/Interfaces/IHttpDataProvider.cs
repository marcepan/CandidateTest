using System.Threading.Tasks;

namespace PairingTest.Web.Interfaces {
   public interface IHttpDataProvider {
      Task<T> Get<T>(string requestUri) where T : class;
   }
}

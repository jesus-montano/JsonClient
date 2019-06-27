using System.Threading.Tasks;
namespace JsonClient
{
  public interface IJsonClient<TModel>
  {
       Task<TModel> GetAsync(string id);
       Task<TModel> GetAsync();

  }  
}
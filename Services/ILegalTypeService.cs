using Teledok.DAL;

namespace Teledok.Services
{
	public interface ILegalTypeService<T> where T : class
	{
		Task<T> Create(T item);
		Task<T> Update(T item);
		Task Delete(int id);
		Task<T> Get(int id);
		List<T> GetList();
	}
}

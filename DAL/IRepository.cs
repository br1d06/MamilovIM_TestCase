namespace Teledok.DAL;

interface IRepository<T> : IDisposable
	where T : class
{
	List<T> GetList();
	Task<T> Get(int taxPayerId); 
	T Create(T item); 
	T Update(T item); 
	Task Delete(int taxPayerId); 
	Task SaveAsync();  
}


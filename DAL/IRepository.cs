namespace Teledok.DAL;

interface IRepository<T> : IDisposable
	where T : class
{
	IEnumerable<T> GetList();
	Task<T> Get(int taxPayerId); 
	void Create(T item); 
	void Update(T item); 
	void Delete(int taxPayerId); 
	void Save();  
}


using Microsoft.AspNetCore.Mvc;
using Teledok.Models;

namespace Teledok.DAL;

public class ClientRepository : IRepository<Client>
{
	private readonly ApiDbContext _context;

	public ClientRepository(ApiDbContext context)
	{
		_context = context;
	}

	public Client Create(Client client)
	{
		_context.Clients.Add(client);
		return client;
	}

	public async Task Delete(int id)
	{
		Client client = await _context.Clients.FindAsync(id);

		if (client != null)
		{
			_context.Clients.Remove(client);
		}
	}

	public async Task<Client> Get(int id)
	{
		return await _context.Clients.FindAsync(id);
	}

	public List<Client> GetList()
	{
		return _context.Clients.ToList();
	}

	public Task SaveAsync()
	{
		return _context.SaveChangesAsync();
	}

	public Client Update(Client client)
	{
		_context.Clients.Update(client);

		return client;

	}
	private bool _disposed = false;
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			if (disposing)
			{
				_context.Dispose();
			}
		}
		_disposed = true;
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

}


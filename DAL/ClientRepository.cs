using Microsoft.AspNetCore.Mvc;
using Teledok.Data;
using Teledok.Models;

namespace Teledok.DAL;

public class ClientRepository : IRepository<Client>, IDisposable
{
	private readonly ApiDbContext _context;

	public ClientRepository(ApiDbContext context)
	{
		_context = context;
	}

	public void Create(Client client)
	{
		client.DateAdded = DateTime.UtcNow;
		client.DateUpdated = DateTime.UtcNow;

		_context.Clients.Add(client);
	}

	public async void Delete(int taxPayerId)
	{
		Client client = await _context.Clients.FindAsync(taxPayerId);

		if (client != null)
		{
			_context.Clients.Remove(client);
		}
	}

	public async Task<Client> Get(int taxPayerId)
	{
		return await _context.Clients.FindAsync(taxPayerId);
	}

	public IEnumerable<Client> GetList()
	{
		return _context.Clients.ToList();
	}

	public async void Save()
	{
		await _context.SaveChangesAsync();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public void Update(Client client)
	{
		client.DateUpdated = DateTime.UtcNow;
		_context.Clients.Update(client);
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


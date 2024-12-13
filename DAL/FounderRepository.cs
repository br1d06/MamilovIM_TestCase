using Microsoft.AspNetCore.Mvc;
using Teledok.Data;
using Teledok.Models;

namespace Teledok.DAL
{
	public class FounderRepository : IRepository<Founder>, IDisposable
	{
		private readonly ApiDbContext _context; 

		public FounderRepository(ApiDbContext context)
		{
			_context = context;
		}
		public void Create(Founder founder)
		{
			founder.DateAdded = DateTime.UtcNow;
			founder.DateUpdated = DateTime.UtcNow;

			_context.Founders.Add(founder);
		}

		public async void Delete(int taxPayerId)
		{
			Founder founder = await _context.Founders.FindAsync(taxPayerId);

			if (founder != null)
			{
				_context.Founders.Remove(founder);
			}
		}

		public async Task<Founder> Get(int taxPayerId)
		{
			return await _context.Founders.FindAsync(taxPayerId);
		}

		public IEnumerable<Founder> GetList()
		{
			return _context.Founders.ToList();
		}

		public async void Save()
		{
			await _context.SaveChangesAsync();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public void Update(Founder founder)
		{
			founder.DateUpdated= DateTime.UtcNow;

			_context.Founders.Update(founder);
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
	
}

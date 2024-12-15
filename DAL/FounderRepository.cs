using Microsoft.AspNetCore.Mvc;
using Teledok.Models;

namespace Teledok.DAL
{
    public class FounderRepository : IRepository<Founder>
	{
		private readonly ApiDbContext _context; 

		public FounderRepository(ApiDbContext context)
		{
			_context = context;
		}
		public Founder Create(Founder founder)
		{
			_context.Founders.Add(founder);

			return founder;
		}

		public async Task Delete(int id)
		{
			Founder founder = await _context.Founders.FindAsync(id);

			if (founder != null)
			{
				_context.Founders.Remove(founder);
			}
		}

		public async Task<Founder> Get(int id) => await _context.Founders.FindAsync(id);
		

		public List<Founder> GetList()
		{
			return _context.Founders.ToList();
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public Founder Update(Founder founder)
		{
			_context.Founders.Update(founder);

			return founder;
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

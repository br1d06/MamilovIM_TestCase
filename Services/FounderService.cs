using Teledok.DAL;
using Teledok.Models;

namespace Teledok.Services
{
	public class FounderService : ILegalTypeService<Founder>
	{
		private readonly FounderRepository _founderRepository;

		public FounderService(FounderRepository founderRepository)
		{
			_founderRepository = founderRepository;
		}

		public FounderService() { }

		public async Task<Founder> Create(Founder founder)
		{
			_founderRepository.Create(founder);
			await _founderRepository.SaveAsync();

			return founder;
		}

		public async Task Delete(int id)
		{
			await _founderRepository.Delete(id);
			await _founderRepository.SaveAsync();
		}

		public async Task<Founder> Update(Founder founder)
		{
			_founderRepository.Update(founder);
			await _founderRepository.SaveAsync();

			return founder;
		}

		public async Task<Founder> Get(int id) => await _founderRepository.Get(id);
		

		public List<Founder> GetList() => _founderRepository.GetList();
		
	}
}

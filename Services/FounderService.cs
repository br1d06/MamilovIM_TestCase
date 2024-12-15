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

		public async Task Delete(Founder founder)
		{
			await _founderRepository.Delete(founder.Id);
			await _founderRepository.SaveAsync();
		}

		public async Task<Founder> Update(Founder founder)
		{
			_founderRepository.Update(founder);
			await _founderRepository.SaveAsync();

			return founder;
		}

		public async Task<Founder> Get(Founder founder)
		{
			return await _founderRepository.Get(founder.Id);
		}

		public List<Founder> GetList()
		{
			return _founderRepository.GetList();
		}
	}
}

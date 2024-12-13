using Microsoft.AspNetCore.Mvc;
using Teledok.DAL;
using Teledok.Models;

namespace Teledok.Controllers
{
	public class FounderController : Controller
	{
		private IRepository<Founder> _founderRepository;

		public FounderController()
		{
			_founderRepository = new FounderRepository(new ApiDbContext());
		}

		public List<Founder> Index()=>(List<Founder>)_founderRepository.GetList();
		

		public Task<Founder> Details(int foundersTaxPayerId)=>_founderRepository.Get(foundersTaxPayerId);
		

		public void CreateFounder(Founder founder)
		{
			_founderRepository.Create(founder);
			_founderRepository.Save();
		}

		public void DeleteFounder(int foundersTaxPayerId)
		{
			_founderRepository.Delete(foundersTaxPayerId);
			_founderRepository.Save();
		}

		public void UpdateFounder(Founder founder)
		{
			_founderRepository.Update(founder);
			_founderRepository.Save();
		}
	}
}

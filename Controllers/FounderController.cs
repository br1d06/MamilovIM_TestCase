using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Teledok.Models;
using Teledok.Services;

namespace Teledok.Controllers
{
	[ApiController]
	class FounderController : Controller
	{
		private readonly FounderService _founderService;

		public FounderController(FounderService founderService)
		{
			_founderService = founderService;
		}

		public List<Founder> Index()=>_founderService.GetList();
		
		public async Task<Founder> Details(Founder founder)=>await _founderService.Get(founder);
		
		public async Task<Founder> CreateFounder(Founder founder)
		{
			await _founderService.Create(founder);

			return founder;
		}

		public async Task DeleteFounder(Founder founder)
		{
			await _founderService.Delete(founder);
		}

		public async Task<Founder> UpdateFounder(Founder founder)
		{
			await _founderService.Update(founder);

			return founder;
		}
	}
}

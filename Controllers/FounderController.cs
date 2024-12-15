using Microsoft.AspNetCore.Mvc;
using Teledok.Models;
using Teledok.Services;

namespace Teledok.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class FounderController : Controller
	{
		private readonly FounderService _founderService;

		public FounderController(FounderService founderService)
		{
			_founderService = founderService;
		}

		[HttpGet]
		public List<Founder> GetList()=>_founderService.GetList();

		[HttpPost]
		public async Task<Founder> Details(int id) => await _founderService.Get(id);

		[HttpPost]
		public async Task<Founder> Create(Founder founder) => await _founderService.Create(founder);

		[HttpPost]
		public async Task Delete(int id)=> await _founderService.Delete(id);

		[HttpPost]
		public async Task<Founder> Update(Founder founder)
		{
			await _founderService.Update(founder);

			return founder;
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Teledok.Models;
using Teledok.Services;

namespace Teledok.Controllers
{

	[ApiController]
	[Route("api/[controller]/[action]")]
	public class ClientController : ControllerBase
	{	
		private readonly ClientService _clientService;

		public ClientController(ClientService clientService)
		{
			_clientService = clientService;
		}

		[HttpGet]
		public List<Client> GetList() => _clientService.GetList();

		[HttpPost]
		public Task<Client> Details(int id) => _clientService.Get(id);

		[HttpPost]
		public async Task<Client> Create(Client client) => await _clientService.Update(client);

		[HttpPost]
		public async Task Delete(int id)=> await _clientService.Delete(id);

		[HttpPost]
		public async Task<Client> Update(Client client) 
		{
			await _clientService.Update(client);

			return client;
		}
	}
}
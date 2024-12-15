using Microsoft.AspNetCore.Mvc;
using Teledok.Models;
using Teledok.Services;

namespace Teledok.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
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
		[Route("api/[controller][action]")]
		public Task<Client> Details(Client client) => _clientService.Get(client);
		[HttpPost]
		[Route("api/[controller][action]")]
		public async Task CreateClient(Client client) =>await _clientService.Update(client);
		[HttpPost]
		[Route("api/[controller][action]")]
		public async Task DeleteClient(Client client)=> await _clientService.Delete(client);
		[HttpPost]
		[Route("api/[controller][action]")]
		public async Task<Client> UpdateClient(Client client) 
		{
			await _clientService.Update(client);

			return client;
		}
	}
}
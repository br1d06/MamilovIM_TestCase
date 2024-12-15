using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Teledok.DAL;
using Teledok.Models;
using Teledok.Services;

namespace Teledok.Controllers
{
	class ClientController : ApiController
	{	
		private readonly ClientService _clientService;

		public ClientController(ClientService clientService)
		{
			_clientService = clientService;
		}

		public List<Client> GetList() => _clientService.GetList();
		
		public Task<Client> Details(Client client) => _clientService.Get(client);

		public async Task CreateClient(Client client) =>await _clientService.Update(client);
		

		public async Task DeleteClient(Client client)=> await _clientService.Delete(client);
		

		public async Task<Client> UpdateClient(Client client) 
		{
			await _clientService.Update(client);

			return client;
		}
	}
}
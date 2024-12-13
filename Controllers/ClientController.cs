using Microsoft.AspNetCore.Mvc;
using Teledok.DAL;
using Teledok.Models;

namespace Teledok.Controllers
{
	public class ClientController : Controller
	{
		private IRepository<Client> _clientRepository;

		public ClientController()
		{
			_clientRepository = new ClientRepository(new ApiDbContext());
		}

		public List<Client> Index()=> (List<Client>)_clientRepository.GetList();
		

		public Task<Client> Details(int clientsTaxPayerId) => _clientRepository.Get(clientsTaxPayerId);

		public void CreateClient(Client client)
		{
			_clientRepository.Create(client);
			_clientRepository.Save();
		}

		public void DeleteClient(int clientsTaxPayerId)
		{
			_clientRepository.Delete(clientsTaxPayerId);
			_clientRepository.Save();
		}

		public void UpdateClient(Client client) 
		{
			_clientRepository.Update(client);
			_clientRepository.Save();
		}
	}
}